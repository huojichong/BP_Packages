using Modules.Core.Runtime;
using UnityEditor;

namespace Modules.SubModule.Module2.Editor_1
{
    public class Module2Editor : Editor
    {
        [ExcelSource("Assets/Excels/Module2.xlsx")]
        [ExcelOutput("Assets/Data/Module2Data.json")]
        public class Module2Excel2Data : IExcel2Data
        {
            public object Process(string excelPath)
            {
                return null;
            }
        }
    }
}