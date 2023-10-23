using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMS_CRUD_ASP.NET_MVC.EF;

namespace UniversityMS_CRUD_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DepartmentList()
        {
            var db = new UMSCRUDEntities();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
        return View();
        }
        [HttpPost]
        public ActionResult Create(Department d) {
            var db = new UMSCRUDEntities();
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var db = new UMSCRUDEntities();
            var data = (from d in db.Departments
                        where d.Department_id == id
                        select d).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            var db = new UMSCRUDEntities();
            var data = db.Departments.Find(d.Department_id);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new UMSCRUDEntities();
            var exdata = db.Departments.Find(id);
            return View(exdata);
        }
        [HttpPost]
        public ActionResult Delete(Department d) {
            var db = new UMSCRUDEntities();
            var data = db.Departments.Find(d.Department_id
                , true);
            db.Departments.Remove(data);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        public ActionResult StudentList()
        {
            var db = new UMSCRUDEntities();
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddStudent(){
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s) { 
            var db = new UMSCRUDEntities();
            var data = db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var db = new UMSCRUDEntities();
            var data = (from d in db.Students
                        where d.student_id == id
                        select d).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditStudent(Student d)
        {
            var db = new UMSCRUDEntities();
            var exdata = db.Students.Find(d.student_id);
            exdata.Student_name = d.Student_name;
            exdata.student_cgpa = d.student_cgpa;
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var db = new UMSCRUDEntities();
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult DeleteStudent(Student d )
        {
            var db = new UMSCRUDEntities();
            var data = db.Students.Find(d.student_id);
            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }




    }
}