using Microsoft.EntityFrameworkCore;
using StudentApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL
{
    public class StudentEntity:DbContext
    {
        public StudentEntity(DbContextOptions<StudentEntity> options):base(options)
        {

        }

        DbSet<TblStudent> tblStudents { get; set; }
        DbSet<TblClass>  tblClasses { get; set; }
        DbSet<TblSubjects> tblSubject { get; set; }
    }
}
