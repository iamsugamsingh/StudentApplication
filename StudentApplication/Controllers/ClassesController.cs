using Microsoft.AspNetCore.Mvc;
using StudentApplication.BAL.IServices;
using StudentApplication.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Resources;

namespace StudentApplication.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        public IActionResult Index()
        {
            var classList = _classService.GetAllClassList();
            if(classList!=null && classList.Count>0)
            {
                ViewBag.ClassesList = classList;
            }

            TblClassViewModel tblClassViewModel = new TblClassViewModel();

            return View(tblClassViewModel);
        }

        [HttpPost]
        public IActionResult AddUpdateClasses(TblClassViewModel tblClassViewModel)
        {
           var status = _classService.AddUpdateClass(tblClassViewModel);
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
            var classData = _classService.GetClassByClassId(id);
            if (classData != null)
            {
                ViewBag.ClassesData = classData;
            }

            var classList = _classService.GetAllClassList();
            if (classList != null && classList.Count > 0)
            {
                ViewBag.ClassesList = classList;
            }
            return View("Index",classData);
        }

        public IActionResult Delete(int id)
        {
            var status = _classService.DeleteClass(id);
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
