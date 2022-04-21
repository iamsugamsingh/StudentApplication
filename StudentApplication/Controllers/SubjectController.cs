using Microsoft.AspNetCore.Mvc;
using StudentApplication.BAL.IServices;
using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IClassService _classService;

        public SubjectController(ISubjectService subjectService, IClassService classService)
        {
            _subjectService = subjectService;
            _classService = classService;
        }
        public IActionResult Index()
        
        {
            var subjectList = _subjectService.GetAllSubjectList();
            if (subjectList != null && subjectList.Count > 0)
            {
                ViewBag.SubjectList = subjectList;
            }

            var classList = _classService.GetAllClassList();
            if (classList != null && classList.Count > 0)
            {
                ViewBag.ClassesList = classList;
            }


            TblSubjectsViewModel tblSubjectsViewModel = new TblSubjectsViewModel();

            return View(tblSubjectsViewModel);
        }

        [HttpPost]
        public IActionResult AddUpdateSubjects(TblSubjectsViewModel tblSubjectsViewModel)
        {
            var status = _subjectService.AddUpdateSubject(tblSubjectsViewModel);
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
            var subjectData = _subjectService.GetSubjectBySubjectId(id);
            if (subjectData != null)
            {
                ViewBag.subjectData = subjectData;
            }

            var subjectList = _subjectService.GetAllSubjectList();
            if (subjectList != null && subjectList.Count > 0)
            {
                ViewBag.SubjectList = subjectList;
            }
            var classList = _classService.GetAllClassList();
            if (classList != null && classList.Count > 0)
            {
                ViewBag.ClassesList = classList;
            }

            return View("Index", subjectData);
        }

        public IActionResult Delete(int id)
        {
            var status = _subjectService.DeleteSubject(id);
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
