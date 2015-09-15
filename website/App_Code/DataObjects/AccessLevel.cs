using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccessLevel
/// 
/// Data Object used to store information about Access Level
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
namespace cisseniorproject.dataobjects
{
    public class AccessLevel
    {
        private int ID;
        private String level;

        public AccessLevel()
        {

        }

        public AccessLevel(int ID, String level)
        {
            this.ID = ID;
            this.level = level;
        }

        public int getID()
        {
            return this.ID;
        }
        public void setID(int ID)
        {
            this.ID = ID;
        }

        public String getLevel()
        {
            return this.level;
        }
        public void setLevel(String level)
        {
            this.level = level;
        }
    }
}