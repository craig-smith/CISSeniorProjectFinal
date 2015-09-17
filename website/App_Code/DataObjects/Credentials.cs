using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * this class holds informaition about user credentials
 * */
namespace cisseniorproject.dataobjects
{


    public class Credentials
    {
        int userId;
        private String username;
        private String password;
        private String accessLevel;
        private String salt;

        public Credentials(int userId, String username, String password, String salt, String accessLevel)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.accessLevel = accessLevel;
        }

        public String getUsername()
        {
            return username;
        }

        public String getPassword()
        {
            return password;
        }

        internal object getAccessLevel()
        {
            return accessLevel;
        }

        public String getSalt()
        {
            return salt;
        }
        public int getUserId()
        {
            return userId;
        }
        
    }
}
