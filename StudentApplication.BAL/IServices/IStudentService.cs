using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.BAL.IServices
{
    public interface IStudentService
    {
        bool AddUpdateStudent(TblStudentViewModel tblStudentViewModel);
        List<TblStudentViewModel> GetAllStudentsList();
        TblStudentViewModel GetStudentByStudentId(long studentId);
        bool DeleteStudent(long studentId);
    }
}
