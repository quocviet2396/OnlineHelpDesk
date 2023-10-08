using System;
using System.Globalization;
using System.Text;
using LibraryModels;

namespace WebApp.Ultils
{
    public class Helper
    {
        public string AnEmail(string email, int numberOfVisibleChars = 3)
        {
            if (!string.IsNullOrEmpty(email))
            {
                int atIndex = email.IndexOf('@');
                if (atIndex > 0)
                {
                    string visiblePart = email.Substring(0, Math.Min(numberOfVisibleChars, atIndex));
                    string hiddenPart = new string('*', Math.Max(0, atIndex - numberOfVisibleChars));
                    string domain = email.Substring(atIndex);
                    return visiblePart + hiddenPart + domain;
                }
            }
            return email;
        }


        public string CreateEmail(string firstname, string lastname)
        {

            string Fname = RemoveDiacriticsAndSpaces(firstname.ToLower().Trim());
            string Lname = RemoveDiacriticsAndSpaces(lastname.ToLower().Trim());
            Random random = new Random();
            string randomNumber = random.Next(1000, 9999).ToString();

            string email = $"{Fname}{Lname}{randomNumber}@gmail.com";

            return email;
        }


        public string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] randomString = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomString[i] = chars[random.Next(chars.Length)];
            }
            string password = new string(randomString);
            return password;
        }

        public Response<T> CreateResponse<T>(string mes, bool success, T? data = default)
        {
            return new Response<T>
            {
                Success = success,
                Msg = mes,
                Data = data
            };
        }

        public static string RemoveDiacriticsAndSpaces(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    // Thay dấu cách bằng dấu gạch dưới (_) hoặc bất kỳ ký tự khác
                    char replacement = (c == ' ') ? '_' : c;
                    stringBuilder.Append(replacement);
                }
            }

            return stringBuilder.ToString();
        }

        public Helper()

        {
        }
    }
}

