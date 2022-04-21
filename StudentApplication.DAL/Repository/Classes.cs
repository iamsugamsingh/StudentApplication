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
    public class Classes:IClasses
    {
        private readonly StudentEntity _studentEntity;
        public Classes(StudentEntity studentEntity)
        {
            _studentEntity = studentEntity;
        }
        public bool AddUpdateClass(TblClassViewModel tblClassViewModel)
        {
            try
            {
                TblClass tblClass = new TblClass();
                if (tblClassViewModel.ClassId == 0)
                {
                    tblClass.ClassId = tblClassViewModel.ClassId;
                    tblClass.ClassName = tblClassViewModel.ClassName;

                    _studentEntity.Add(tblClass);
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }
                else
                {

                    var data = (_studentEntity.Set<TblClass>().ToList()).Where(id => id.ClassId.Equals(tblClassViewModel.ClassId)).FirstOrDefault();
                    //data.ClassId = tblClassViewModel.ClassId;
                    data.ClassName = tblClassViewModel.ClassName;
                    int count = _studentEntity.SaveChanges();

                    return count > 0 ? true : false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteClass(int classId)
        {
            var data = _studentEntity.Set<TblClass>().Where(id => id.ClassId.Equals(classId)).FirstOrDefault();
            if (data != null)
                data.ClassId = classId;
            _studentEntity.Remove(data);
            var count = _studentEntity.SaveChanges();

            return count > 0 ? true : false;

        }

        public List<TblClassViewModel> GetAllClassList()
{
            var data = _studentEntity.Set<TblClass>().ToList();
            List<TblClassViewModel> tblClassViewModelList = new List<TblClassViewModel>();

            foreach (var item in data)
            {
                tblClassViewModelList.Add(new TblClassViewModel
                {
                    ClassId = item.ClassId,
                    ClassName = item.ClassName,
                });

            }
            return tblClassViewModelList;
        }

        public TblClassViewModel GetClassByClassId(int classId)
        {
            TblClassViewModel tblClassViewModel = new TblClassViewModel();
            var data = (_studentEntity.Set<TblClass>().ToList()).Where(id => id.ClassId.Equals(classId)).FirstOrDefault();
            tblClassViewModel.ClassId = data.ClassId;
            tblClassViewModel.ClassName = data.ClassName;

            return tblClassViewModel;
        }
    }
}
