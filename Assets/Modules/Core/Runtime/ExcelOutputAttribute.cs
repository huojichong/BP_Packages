using System;

namespace Modules.Core.Runtime
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExcelOutputAttribute : Attribute
    {
        public string Path { get; }

        public ExcelOutputAttribute(string path)
        {
            Path = path;
        }
    }
}