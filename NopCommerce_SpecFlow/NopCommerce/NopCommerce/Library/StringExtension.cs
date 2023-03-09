using System.Net.Mail;
using System.Reflection;

namespace NopCommerce.Library
{
    public static class StringExtensions
    {
        public static string GetAbsolutePath(this string filePath)
        {
            string directoryPath =
                Path
                    .Combine(Path
                        .GetDirectoryName(Assembly
                            .GetExecutingAssembly()
                            .Location),
                    filePath);

            if (File.Exists(directoryPath))
            {
                return directoryPath;
            }
            return string.Empty;
        }

        public static string GetTextFromJsonFile(this string filePath)
        {
            string pathFile = filePath.GetAbsolutePath();
            return File.ReadAllText(pathFile);
        }

        public static string AddUniquePath(this string text)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            Random r = new Random();
            int rInt = r.Next(0, 100);
            return text + " " + timeStamp + rInt;
        }

        public static string InitializeUniqueString(this string text)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            Random r = new Random();
            int rInt = r.Next(0, 100);
            return timeStamp + rInt + text;
        }

        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString("[ dd/MM/yyyy HH:mm:ss ]");
        }

        public static bool IsValidEmail(this string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}