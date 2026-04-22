using System;

namespace Modules.Core.Editor
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