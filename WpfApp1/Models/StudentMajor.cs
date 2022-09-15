 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class StudentMajor
    {
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Major { get; set; }
        public bool? Male { get; set; }
        public int Id { get; set; }

     

        public StudentMajor(string name, DateTime? dob, string major, bool? male)
        {
            Name = name;
            Dob = dob;
            Major = major;
            Male = male;
        }
    }
}
