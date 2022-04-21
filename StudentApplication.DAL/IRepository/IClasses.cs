using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL.IRepository
{
    public interface IClasses
    {
        bool AddUpdateClass(TblClassViewModel tblClassViewModel);
        List<TblClassViewModel> GetAllClassList();
        TblClassViewModel GetClassByClassId(int classId);
        bool DeleteClass(int classId);
    }
}
