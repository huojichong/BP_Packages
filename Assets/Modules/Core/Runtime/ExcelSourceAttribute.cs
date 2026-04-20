using System;

namespace Modules.Core.Runtime
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExcelSourceAttribute : Attribute
    {
        public string Path { get; }

        public ExcelSourceAttribute(string path)
        {
            Path = path;
        }
    }
}