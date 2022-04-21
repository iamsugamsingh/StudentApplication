using System;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Model.ViewModels
{
    public class TblStudentViewModel
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }
        public long SubjectId { get; set; }
        public Decimal Marks { get; set; }
    }
}
