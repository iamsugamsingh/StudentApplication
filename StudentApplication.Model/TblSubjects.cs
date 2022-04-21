using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Model
{
    public class TblSubjects
    {
        [Key]
        public long SubjectId { get; set; }
        public int ClassId { get; set; }
        public string SubjectName { get; set; }
    }
}
