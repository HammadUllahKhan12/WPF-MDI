using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserInfo
    {
        public UserInfo()
        { }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string Comments { get; set; }
        public string AddedByUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public string IsAdminDescription { get; set; }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
