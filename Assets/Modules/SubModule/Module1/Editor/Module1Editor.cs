using System;
using System.IO;
using Modules.Core.Runtime;

namespace Modules.SubModule.Module1.Editor
{
    public class Module1Editor : UnityEditor.Editor
    {
        [ExcelSource("Assets/Excels/Module1.xlsx")]
        [ExcelOutput("Assets/Data/Module1Data.json")]
        public class Module1Excel2Data : IExcel2Data
        {
            public object Process(string excelPath)
            {
                return new
                {
                    Name = Path.GetFileNameWithoutExtension(excelPath),
                    Common = true
                };
            }
        }
    }
}