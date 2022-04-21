using StudentApplication.DAL.IRepository;
using StudentApplication.Model;
using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL.Repository
{
    public class Subject : ISubject
    {
        private readonly StudentEntity _studentEntity;
        public Subject(StudentEntity studentEntity)
        {
            _studentEntity = studentEntity;
        }
        public bool AddUpdateSubject(TblSubjectsViewModel tblSubjectsViewModel)
        {
            try
            {
                TblSubjects tblSubjects = new TblSubjects();
                if (tblSubjectsViewModel.SubjectId == 0)
                {
                    tblSubjects.SubjectId = tblSubjectsViewModel.SubjectId;
                    tblSubjects.SubjectName = tblSubjectsViewModel.SubjectName;
                    tblSubjects.ClassId = tblSubjectsViewModel.ClassId;

                    _studentEntity.Add(tblSubjects);
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }
                else
                {

                    var data = _studentEntity.Set<TblSubjects>().Where(id => id.SubjectId.Equals(tblSubjectsViewModel.SubjectId)).FirstOrDefault();
                    data.SubjectId = tblSubjectsViewModel.SubjectId;
                    data.SubjectName = tblSubjectsViewModel.SubjectName;
                    data.ClassId = tblSubjectsViewModel.ClassId;
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSubject(long subjectId)
        {
            var data = _studentEntity.Set<TblSubjects>().Where(id => id.SubjectId.Equals(subjectId)).FirstOrDefault();
            if (data != null)
                data.SubjectId = subjectId;
            _studentEntity.Remove(data);
            var count = _studentEntity.SaveChanges();

            return count > 0 ? true : false;
        }

        public List<TblSubjectsViewModel> GetAllSubjectList()
        {
            var SubjectData = _studentEntity.Set<TblSubjects>().ToList();
            var ClassData = _studentEntity.Set<TblClass>().ToList();
            List<TblSubjectsViewModel> tblSubjectsViewModel = new List<TblSubjectsViewModel>();



            foreach (var item in SubjectData)
            {
                if (item.ClassId != 0)
                {
                    var clsName = ClassData.Where(id => id.ClassId.Equals(item.ClassId)).FirstOrDefault();
                    tblSubjectsViewModel.Add(new TblSubjectsViewModel
                    {
                        SubjectId = item.SubjectId,
                        ClassId = item.ClassId,
                        ClassName = clsName.ClassName,
                        SubjectName = item.SubjectName,
                    });
                }
            }
            return tblSubjectsViewModel;
        }


        public List<TblSubjectsViewModel> GetSubjectListByClassId(int classId)
        {
            var SubjectData = _studentEntity.Set<TblSubjects>().Where(s=>s.ClassId.Equals(classId)).ToList();
            List<TblSubjectsViewModel> tblSubjectsViewModel = new List<TblSubjectsViewModel>();

            foreach (var item in SubjectData)
            {
                if (item.ClassId != 0)
                {
                    //var clsName = ClassData.Where(id => id.ClassId.Equals(item.ClassId)).FirstOrDefault();
                    tblSubjectsViewModel.Add(new TblSubjectsViewModel
                    {
                        SubjectId = item.SubjectId,
                        //ClassId = item.ClassId,
                        //ClassName = clsName.ClassName,
                        SubjectName = item.SubjectName,
                    });
                }
            }
            return tblSubjectsViewModel;
        }

        public TblSubjectsViewModel GetSubjectBySubjectId(long subjectId)
        {
            TblSubjectsViewModel tblSubjectsViewModel = new TblSubjectsViewModel();
            var data = _studentEntity.Set<TblSubjects>().Where(id => id.SubjectId.Equals(subjectId)).FirstOrDefault();
            tblSubjectsViewModel.SubjectId = data.SubjectId;
            tblSubjectsViewModel.SubjectName = data.SubjectName;
            tblSubjectsViewModel.ClassId = data.ClassId;

            return tblSubjectsViewModel;
        }
    }
}
