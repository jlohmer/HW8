using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SoonerID { get; set; }
        public string FourByFour { get; set; }
        public string Email { get; set; }
        public string ResidentStatus { get; set; }
        public string Level { get; set; }
        public string RegistrationDate { get; set; }
       public  Dictionary<string, List<string>> ProgramCodes { get; set; }

        public Student()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            SoonerID = string.Empty;
            FourByFour = string.Empty;
            Email = string.Empty;
            ResidentStatus = string.Empty;
            Level = string.Empty;
            RegistrationDate = string.Empty;
            ProgramCodes = new Dictionary<string, List<string>>();
            ProgramCodes.Add("MAJOR", new List<string>());
            ProgramCodes.Add("MINOR", new List<string>());
        }
    }
}
