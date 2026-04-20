using Modules.Core.Runtime;
using UnityEditor;
using UnityEngine;

namespace Modules.SubModule.Module1.Editor
{
    public class Module1Editor : UnityEditor.Editor
    {
        public class Module1Excel2Data : IExcel2Data
        {
            public void Excel2Data()
            {
                Debug.Log("Module 1 Excel to Data");
            }
        }
        
        [MenuItem("Modules/Create/Module1 excel to data")]
        public static void ModuleExcel2Data()
        {
            var excel2Data = new Module1Excel2Data();
            excel2Data.Excel2Data();
        }
    }
}