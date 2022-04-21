using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.BAL.IServices
{
    public interface ISubjectService
    {
        bool AddUpdateSubject(TblSubjectsViewModel tblSubjectsViewModel);
        List<TblSubjectsViewModel> GetAllSubjectList();
        TblSubjectsViewModel GetSubjectBySubjectId(long subjectId);
        bool DeleteSubject(long subjectId);
        List<TblSubjectsViewModel> GetSubjectListByClassId(int classId);
    }
}
