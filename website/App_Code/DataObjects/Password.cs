using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Password
/// 
/// Data Object used to store information about passwords
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class Password
    {
        private int passwordId;
        private String password;
        private String salt;

        public Password()
        {

        }

        public Password(int passwordId, String password, String salt)
        {
            this.passwordId = passwordId;
            this.password = password;
            this.salt = salt;
        }

        public int getPasswordId()
        {
            return this.passwordId;
        }
        public void setPasswordId(int passwordId)
        {
            this.passwordId = passwordId;
        }

        public String getPassword()
        {
            return this.password;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getSalt()
        {
            return this.salt;
        }
        public void setSalt(String salt)
        {
            this.salt = salt;
        }
    }
}