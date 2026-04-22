using System;

namespace Modules.Core.Editor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExcelHandlerAttribute : Attribute
    {
        public string ExcelName { get; }

        public ExcelHandlerAttribute(string excelName)
        {
            ExcelName = excelName;
        }
    }
}