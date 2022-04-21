using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL.IRepository
{
    public interface ISubject
    {
        bool AddUpdateSubject(TblSubjectsViewModel tblSubjectsViewModel);
        List<TblSubjectsViewModel> GetAllSubjectList();
        TblSubjectsViewModel GetSubjectBySubjectId(long subjectId);
        bool DeleteSubject(long subjectId);
        List<TblSubjectsViewModel> GetSubjectListByClassId(int classId);
    }
}
