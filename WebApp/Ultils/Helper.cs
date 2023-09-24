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


        public string CreateEmail(string firstname, string lastname, DateTime dob)
        {
            DateTime dateTime = DateTime.ParseExact(dob.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            int year = dateTime.Year;
            int month = dateTime.Month;

            // Lấy hai chữ số cuối cùng của năm
            string lastTwoDigitsOfYear = year.ToString().Substring(2);

            // Kết quả
            string Dob = lastTwoDigitsOfYear + month.ToString("D2");
            // Loại bỏ các ký tự không hợp lệ từ firstname và lastname (nếu cần)
            string Fname = firstname.ToLower();
            string Lname = lastname.ToLower();
            Random random = new Random();
            string randomNumber = random.Next(10, 99).ToString();

            string email = $"{Fname}{Lname}{Dob}{randomNumber}@gmail.com";

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

        public Response CreateResponse(string mes, bool success)
        {
            return new Response
            {
                Success = success,
                Msg = mes
            };
        }


        public Helper()

        {
        }
    }
}

