using PhatT1808A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhatT1808A.Controllers
{
    public class ClassLateController : Controller
    {
        private static Dictionary<int, ClassLate> _ClassLate = new Dictionary<int, ClassLate>();
        private Context db = new Context();

        // GET: ClassLate
        public ActionResult Index()
        {
            return View(_ClassLate.Values.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Add(ClassLate classLate)
        {
            _ClassLate.Add(classLate.StudentId, classLate);
            db.ClassLates.Add(classLate);
            db.SaveChanges();
            return Redirect("/ClassLate/Get");
        }
        public ActionResult Get()
        {
            // Dictionary<int, ClassLate> _ClassLate = new Dictionary<int, ClassLate>();           
            return View("Index",_ClassLate.Values.ToList());
        }
    }
}