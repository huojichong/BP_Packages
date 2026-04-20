using System;
using System.IO;
using System.Linq;
using Modules.Core.Runtime;
using UnityEditor;
using UnityEngine;

namespace Modules.Core.Editor
{
    public class CoreExcelEditor : UnityEditor.Editor
    {
        private const string ExcelFolder = "Assets/Excels/";
        private const string OutputFolder = "Assets/Data/";

        [MenuItem("Modules/Create/AllExcel2Data")]
        public static void AllExcel2Data()
        {
            var interfaceType = typeof(IExcel2Data);

            // 找到所有特殊处理器
            var handlers = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a =>
                {
                    try
                    {
                        return a.GetTypes();
                    }
                    catch
                    {
                        return Type.EmptyTypes;
                    }
                })
                .Where(t =>
                    interfaceType.IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract
                )
                .ToDictionary(
                    t =>
                    {
                        var attr =
                            (ExcelHandlerAttribute)
                            Attribute.GetCustomAttribute(
                                t,
                                typeof(ExcelHandlerAttribute));

                        return attr?.ExcelName;
                    },
                    t => t
                );

            // 扫描所有 Excel 文件
            var excelFiles =
                Directory.GetFiles(
                    ExcelFolder,
                    "*.xlsx",
                    SearchOption.TopDirectoryOnly);

            foreach (var excelPath in excelFiles)
            {
                var excelName = Path.GetFileNameWithoutExtension(excelPath);

                object result;

                // 优先使用特殊处理器
                if (handlers.TryGetValue(
                        excelName,
                        out var handlerType))
                {
                    Debug.Log($"使用特殊处理器：{excelName}");

                    var instance =
                        (IExcel2Data)
                        Activator.CreateInstance(handlerType);

                    result = instance.Process(excelPath);
                }
                else
                {
                    Debug.Log($"使用默认处理器：{excelName}");

                    result = DefaultExcelProcessor.Process(excelPath);
                }

                var json =
                    JsonUtility.ToJson(result, true);

                var outputPath =
                    Path.Combine(
                        OutputFolder,
                        excelName + ".json");

                File.WriteAllText(outputPath, json);
            }

            AssetDatabase.Refresh();

            Debug.Log("全部 Excel 导出完成");
        }
    }
}