using System;
using System.Linq;
using Modules.Core.Runtime;
using UnityEditor;

namespace Modules.Core.Editor
{
    public class CoreExcelEditor : UnityEditor.Editor
    {
        [MenuItem("Modules/Create/AllExcel2Data")]
        public static void AllExcel2Data()
        {
            // 查找所有继承 IExcel2Data 的脚本
            var interfaceType = typeof(IExcel2Data);

            var types = AppDomain.CurrentDomain
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
                );

            foreach (var type in types)
            {
                try
                {
                    var instance = (IExcel2Data)Activator.CreateInstance(type);
                    instance.Excel2Data();
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogError(
                        $"创建实例失败: {type.FullName}\n{e}"
                    );
                }
            }
        } 
    }
}