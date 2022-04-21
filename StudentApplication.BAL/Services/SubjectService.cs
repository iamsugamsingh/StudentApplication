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
    public class SubjectService : ISubjectService
    {
        private readonly ISubject _subject;
        public SubjectService(ISubject subject)
        {
            _subject = subject;
        }
        public bool AddUpdateSubject(TblSubjectsViewModel tblSubjectsViewModel)
        {
            return _subject.AddUpdateSubject(tblSubjectsViewModel);
        }

        public bool DeleteSubject(long subjectId)
        {
            return _subject.DeleteSubject(subjectId);
        }

        public List<TblSubjectsViewModel> GetAllSubjectList()
        {
            return _subject.GetAllSubjectList();
        }
        public List<TblSubjectsViewModel> GetSubjectListByClassId(int classId)
        {
            return _subject.GetSubjectListByClassId(classId);
        }



        public TblSubjectsViewModel GetSubjectBySubjectId(long subjectId)
        {
            return _subject.GetSubjectBySubjectId(subjectId);
        }
    }
}
