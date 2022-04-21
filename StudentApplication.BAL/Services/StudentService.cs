using StudentApplication.BAL.IServices;
using StudentApplication.DAL.IRepository;
using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.BAL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _student;
        public StudentService(IStudent student)
        {
            _student = student;
        }
        public bool AddUpdateStudent(TblStudentViewModel tblStudentViewModel)
        {
            return _student.AddUpdateStudent(tblStudentViewModel);
        }

        public bool DeleteStudent(long studentId)
        {
            return _student.DeleteStudent(studentId);
        }

        public List<TblStudentViewModel> GetAllStudentsList()
        {
            return _student.GetAllStudentsList();
        }

        public TblStudentViewModel GetStudentByStudentId(long studentId)
        {
            return _student.GetStudentByStudentId(studentId);
        }
    }
}
