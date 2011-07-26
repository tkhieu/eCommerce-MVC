using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DataValidate
    {
        public static bool Account(ref ACCOUNT account, string username, string password, string name, string address, string tel,string socialId, string email, int question, string answer)
        {
            bool flag = true;
            try
            {
                account.Username = username;
                account.Password = password;
                account.Name = name;
                account.Address = address;
                account.Tel = tel;
                account.SocialID = socialId;
                account.Email = email;
                account.Question = question;
                account.Answer = answer;

            }
            catch (Exception)
            {
                flag = false;                
                throw;
            }

            return flag;
        }
    }
}
