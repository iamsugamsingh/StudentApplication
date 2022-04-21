using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.BAL.IServices
{
    public interface IClassService
    {
        bool AddUpdateClass(TblClassViewModel tblClassViewModel);
        List<TblClassViewModel> GetAllClassList();
        TblClassViewModel GetClassByClassId(int classId);
        bool DeleteClass(int classId);
    }
}
