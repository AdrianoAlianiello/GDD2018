using System;
using System.Collections.Generic;

namespace Support
{
    public static class Validator
    {
        public static bool ValidateNotEmptyString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            return true;
        }

        public static bool ValidateNotEmptyDate(DateTime? value)
        {
            if (!value.HasValue)
                return false;
            return true;
        }

        public static bool ValidateNotEmptyCollection<T>(ICollection<T> collection)
        {
            if (collection.Count == 0)
                return false;
            return true;
        }

        public static bool ValidateMailAddress(string text)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(text);
                return addr.Address == text;
            }
            catch
            {
                return false;
            }
        }
    }
}
