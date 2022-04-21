using System;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Model
{
    public class TblStudent
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClassId { get; set; }
        public long SubjectId { get; set; }
        public Decimal Marks { get; set; }
    }
}
