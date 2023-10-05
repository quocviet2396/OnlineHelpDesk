using System;
using System.Globalization;
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

            string Fname = firstname.ToLower();
            string Lname = lastname.ToLower();
            Random random = new Random();
            string randomNumber = random.Next(10000, 99999).ToString();

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


        public Helper()

        {
        }
    }
}

