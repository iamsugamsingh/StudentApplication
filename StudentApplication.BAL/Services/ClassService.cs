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
    public class ClassService : IClassService
    {
        private readonly IClasses _classes;
        public ClassService(IClasses classes)
        {
            _classes=classes;
        }
        public bool AddUpdateClass(TblClassViewModel tblClassViewModel)
        {
            return _classes.AddUpdateClass(tblClassViewModel);
        }

        public bool DeleteClass(int classId)
        {
            return _classes.DeleteClass(classId);
        }

        public List<TblClassViewModel> GetAllClassList()
        {
            return _classes.GetAllClassList();
        }

        public TblClassViewModel GetClassByClassId(int classId)
        {
            return _classes.GetClassByClassId(classId);
        }
    }
}
