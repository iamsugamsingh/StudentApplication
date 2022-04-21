using Microsoft.AspNetCore.Mvc;
using StudentApplication.BAL.IServices;
using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IClassService _classService;
        public StudentController(IStudentService studentService, ISubjectService subjectService, IClassService classService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _classService = classService;
        }
        public IActionResult Index()
        
        {
            var studentList = _studentService.GetAllStudentsList();
            if (studentList != null && studentList.Count > 0)
            {
                ViewBag.StudentList = studentList;
            }

            var classList = _classService.GetAllClassList();
            if (classList != null && classList.Count > 0)
            {
                ViewBag.ClassesList = classList;
            }

            var subjectList = _subjectService.GetSubjectListByClassId(0);
            if (subjectList != null)
            {
                ViewBag.subjectList = subjectList;
            }

            TblStudentViewModel tblStudentViewModel = new TblStudentViewModel();

            return View(tblStudentViewModel);
        }


        public JsonResult GetSubjectDDL(int classId)
        {
            var SubjectDDLList = _subjectService.GetSubjectListByClassId(classId);
            return Json(SubjectDDLList);
        }

        [HttpPost]
        public IActionResult AddUpdateStudents(TblStudentViewModel tblStudentViewModel)
        {
            var status = _studentService.AddUpdateStudent(tblStudentViewModel);
            if (status)
            {
                TempData["status"] = "Data saved successfully!";
            }
            else
            {
                TempData["status"] = "Data can't be saved!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var studentsData = _studentService.GetStudentByStudentId(id);
            
            var classList = _classService.GetAllClassList();
            if (classList != null && classList.Count > 0)
            {
                ViewBag.ClassesList = classList;
            }

            var subjectList = _subjectService.GetSubjectListByClassId(studentsData.ClassId);
            if (subjectList != null && subjectList.Count > 0)
            {
                ViewBag.subjectList = subjectList;
            }

            var studentList = _studentService.GetAllStudentsList();
            if (studentList != null && studentList.Count > 0)
            {
                ViewBag.StudentList = studentList;
            }

            return View("Index", studentsData);
        }

        public IActionResult Delete(int id)
        {
            var status = _studentService.DeleteStudent(id);
            if (status)
            {
                TempData["status"] = "Data deleted successfull!";
            }
            else
            {
                TempData["status"] = "Data can't be deleted!";
            }


            return RedirectToAction("Index");
        }
    }
}
