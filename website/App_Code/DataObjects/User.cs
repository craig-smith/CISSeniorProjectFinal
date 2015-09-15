using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// 
/// Data Object used to hold a single user
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class User
    {
        private int id;
        private String username;
        private String firstName;
        private String lastName;
        private String city;
        private String state;
        private String zipCode;
        private DateTime accountCreationDate;


        public User()
        {

        }

        public User(int id, String username, String firstName, String lastName,
            String city, String state, String zipCode, DateTime accountCreationDate)
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.accountCreationDate = accountCreationDate;
        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public String getUsername()
        {
            return this.username;

        }
        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getFirstName()
        {
            return this.firstName;
        }
        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String getLastName()
        {
            return this.lastName;
        }
        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String getCity()
        {
            return this.city;
        }
        public void setCity(String city)
        {
            this.city = city;
        }

        public String getState()
        {
            return this.state;
        }
        public void setState(String state)
        {
            this.state = state;
        }

        public String getZipCode()
        {
            return this.zipCode;
        }
        public void setZipCode(String zipCode)
        {
            this.zipCode = zipCode;
        }

        public DateTime getAccountCreationDate()
        {
            return this.accountCreationDate;
        }
        public void setAccountCreationDate(DateTime accountCreationDate)
        {
            this.accountCreationDate = accountCreationDate;
        }
    }
}