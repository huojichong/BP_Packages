using Modules.Core.Runtime;
using UnityEditor;
using UnityEngine;

namespace Modules.SubModule.Module2.Editor_1
{
    public class Module2Editor : UnityEditor.Editor
    {
        public class Module2Excel2Data : IExcel2Data
        {
            public void Excel2Data()
            {
                Debug.Log("Module 2 Excel to Data");
            }
        }
        
        [MenuItem("Modules/Create/Module2 excel to data")]
        public static void ModuleExcel2Data()
        {
            var excel2Data = new Module2Excel2Data();
            excel2Data.Excel2Data();
        }

    }
}