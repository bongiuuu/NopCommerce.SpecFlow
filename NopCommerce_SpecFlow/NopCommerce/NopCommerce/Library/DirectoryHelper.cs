using System.Reflection;

namespace NopCommerce.Library
{
    public static class DirectoryHelper
    {
        public static void CreateIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string GetCurrentDirectoryPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}