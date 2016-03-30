using System.Linq;
using System.Web.Mvc;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Controllers
{
    public class StudentsController : Controller
    {
        #region Private Members

        private UnitOfWorkContext _context;

        #endregion

        #region Contructors

        public StudentsController()
        {
            _context = new UnitOfWorkContext();
        }

        #endregion

        #region Public Action Methods

        /// <summary>
        /// Get Method to fetch all Students
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_context.Students.AsNoTracking().ToList());
        }

        /// <summary>
        /// Get Method to return student view to create student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View("Student");
        }

        /// <summary>
        /// Post Method to save student
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateStudent(Student studnet)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get Method to call edit action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStudent()
        {
            return View("Index");
        }

        /// <summary>
        /// Post method to submit edited data to database
        /// </summary>
        /// <param name="disposing"></param>
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Post method to delete action
        /// </summary>
        /// <param name="disposing"></param>
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region IDisposable Methods

        /// <summary>
        /// Method to dispose controller
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}