using System.IO;

namespace Modules.Core.Editor
{
    public class DefaultExcelProcessor
    {
        public static object Process(string excelPath)
        {
            // 这里写你的统一解析逻辑
            return new
            {
                Name = Path.GetFileNameWithoutExtension(excelPath),
                Common = true
            };
        }
    }
}