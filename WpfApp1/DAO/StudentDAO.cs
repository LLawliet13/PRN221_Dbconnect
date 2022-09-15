using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DAO
{
    internal class StudentDAO
    {
        PRN221_FirstExContext context = new PRN221_FirstExContext();
        //return 0 : fail
        //return 1 : success
        public int add(Student student)
        {
            context.Add(student);
            return context.SaveChanges();
        }
        public DbSet<Student> getAll()
        {
            return context.Students;
        }
        public int update(Student student)
        {
            context.Update(student);
            return context.SaveChanges();
        }
        public int delete(Student student)
        {
            context.Remove(student);
            return context.SaveChanges();
        }
    }
}
