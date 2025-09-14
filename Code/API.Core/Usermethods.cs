using Code.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public static class Usermethods
    {
        public static Usermodel AuthenticateUser(Usermodel login)
        {
            Usermodel user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (login.Username.ToLower() == "manideep" && login.Password == "manideep@123")
            {
                user = new Usermodel { Status = "Success", Username = login.Username, EmailAddress = login.EmailAddress, DateofJoining = login.DateofJoining };
            }
            else
            {
                user = new Usermodel { Status = "Login Failed", Username = login.Username, EmailAddress = login.EmailAddress, DateofJoining = login.DateofJoining };
            }
            return user;
        }
    }
}
