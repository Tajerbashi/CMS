using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models.Function_Codes
{
    public static class MachineKeys
    {
        public static string SampleEncode(string word)
        {
            var encrypt = System.Web.Security.MachineKey.Protect(System.Text.Encoding.UTF8.GetBytes(word));
            return Convert.ToBase64String(encrypt);
        }
        public static string KeyEncode(string word,string key)
        {
            var encrypt = System.Web.Security.MachineKey.Protect(System.Text.Encoding.UTF8.GetBytes(word), key);
            return Convert.ToBase64String(encrypt);
        }
        public static string SampleDecode(string word)
        {
            string decrypt = System.Text.Encoding.UTF8.GetString(System.Web.Security.MachineKey.Unprotect(Convert.FromBase64String(word)));
            return decrypt;
        }
        public static string KeyDecode(string word, string key)
        {
            string decrypt = System.Text.Encoding.UTF8.GetString(System.Web.Security.MachineKey.Unprotect(Convert.FromBase64String(word), key));
            return decrypt;
        }
    }
}