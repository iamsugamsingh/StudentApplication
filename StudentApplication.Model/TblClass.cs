using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Model
{
    public class TblClass
    {
        [Key]
        public int ClassId { get; set; }
        public String ClassName { get; set; }
    }
}
