using System;

namespace Modules.Core.Runtime
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