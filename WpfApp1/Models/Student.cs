using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Student
    {
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Major { get; set; }
        public bool? Male { get; set; }
        public int Id { get; set; }

        public Student(string name, DateTime? dob, string major, bool? male)
        {
            Name = name;
            Dob = dob;
            Major = major;
            Male = male;
        }
    }
}
