using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Model.ViewModels
{
    public class TblSubjectsViewModel
    {
        [Key]
        public long SubjectId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
    }
}
