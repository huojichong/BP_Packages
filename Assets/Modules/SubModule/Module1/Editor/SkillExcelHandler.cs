using Modules.Core.Runtime;
using UnityEngine;

namespace Modules.SubModule.Module1.Editor
{
    [ExcelHandler("Skill")]
    public class SkillExcelHandler : IExcel2Data
    {
        public object Process(string excelPath)
        {
            Debug.Log("Skill 表使用特殊处理逻辑");

            // 完全自由写法

            return new
            {
                Type = "Skill",
                Special = true
            };
        }
    }
}