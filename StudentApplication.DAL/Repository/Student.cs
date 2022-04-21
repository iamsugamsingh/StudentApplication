using Microsoft.Extensions.Configuration;
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
    public class Student : IStudent
    {
        private readonly StudentEntity _studentEntity;
        public Student(StudentEntity studentEntity)
        {
            _studentEntity = studentEntity;
        }
        public bool AddUpdateStudent(TblStudentViewModel tblStudentViewModel)
        {
            try
            {
                TblStudent tblStudent = new TblStudent();
                if(tblStudentViewModel.Id==0)
                {
                    tblStudent.Id = tblStudentViewModel.Id;
                    tblStudent.FirstName = tblStudentViewModel.FirstName;
                    tblStudent.LastName = tblStudentViewModel.LastName;
                    tblStudent.ClassId = tblStudentViewModel.ClassId;
                    tblStudent.SubjectId = tblStudentViewModel.SubjectId;
                    tblStudent.Marks = tblStudentViewModel.Marks;

                    _studentEntity.Add(tblStudent);
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }
                else
                {

                    var data = _studentEntity.Set<TblStudent>().Where(id => id.Id.Equals(tblStudentViewModel.Id)).FirstOrDefault();
                    data.Id = tblStudentViewModel.Id;
                    data.FirstName = tblStudentViewModel.FirstName;
                    data.LastName = tblStudentViewModel.LastName;
                    data.ClassId = tblStudentViewModel.ClassId;
                    data.SubjectId = tblStudentViewModel.SubjectId;
                    data.Marks = tblStudentViewModel.Marks;
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeleteStudent(long studentId)
        {
            var data = _studentEntity.Set<TblStudent>().Where(id => id.Id.Equals(studentId)).FirstOrDefault();
            if(data!=null)
                data.Id = studentId;
            _studentEntity.Remove(data);
            var count= _studentEntity.SaveChanges();

            return count > 0 ? true : false;

        }

        public List<TblStudentViewModel> GetAllStudentsList()
        {
            var data= _studentEntity.Set<TblStudent>().ToList();
            var ClassData = _studentEntity.Set<TblClass>().ToList();
            var SubjectData = _studentEntity.Set<TblSubjects>().ToList();

            List<TblStudentViewModel> tblStudentViewModelList = new List<TblStudentViewModel>();

            foreach (var item in data)
            {
                var clsName = ClassData.Where(id => id.ClassId.Equals(item.ClassId)).FirstOrDefault();
                var subName = SubjectData.Where(id => id.SubjectId.Equals(item.SubjectId)).FirstOrDefault();

                tblStudentViewModelList.Add(new TblStudentViewModel { 
                    Id=item.Id,
                    FirstName=item.FirstName,
                    LastName=item.LastName,
                    SubjectName=subName.SubjectName,
                    ClassName=clsName.ClassName,
                    ClassId=item.ClassId,
                    SubjectId=item.SubjectId,
                    Marks=item.Marks
                });

            }
            return tblStudentViewModelList;
        }

        public TblStudentViewModel GetStudentByStudentId(long studentId)
        {
            TblStudentViewModel tblStudentViewModel = new TblStudentViewModel();
            var data = _studentEntity.Set<TblStudent>().Where(id => id.Id.Equals(studentId)).FirstOrDefault();
            tblStudentViewModel.Id = data.Id;
            tblStudentViewModel.FirstName = data.FirstName;
            tblStudentViewModel.LastName = data.LastName;
            tblStudentViewModel.ClassId = data.ClassId;
            tblStudentViewModel.SubjectId = data.SubjectId;
            tblStudentViewModel.Marks = data.Marks;

            return tblStudentViewModel;
        }
    }
}
