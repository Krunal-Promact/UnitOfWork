using System.Linq;
using System.Web.Mvc;
using UnitOfWorkDemo.Models;
using UnitOfWorkDemo.Repository;

namespace UnitOfWorkDemo.Controllers
{
    public class StudentsController : Controller
    {
        #region Private Members

        private GenericUnitOfWork _unitOfWork;

        #endregion

        #region Contructors

        public StudentsController()
        {
            _unitOfWork = new GenericUnitOfWork();
        }

        #endregion

        #region Public Action Methods

        /// <summary>
        /// Get Method to fetch all Students
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Student>().Get().ToList());
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
        public ActionResult CreateStudent([Bind(Exclude = "Id")]Student studnet)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Student>().Insert(studnet);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Student", studnet);
        }

        /// <summary>
        /// Get Method to call edit action
        /// </summary>
        /// <param name="Id">Id of the Student to be edited</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStudent(int Id)
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
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Student>().Update(student);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Student", student);
        }

        /// <summary>
        /// Post method to delete student
        /// </summary>
        /// <param name="id">Id of the Student to be Deleted</param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult DeleteStudent(int id)
        {
            _unitOfWork.Repository<Student>().Delete(id);
            _unitOfWork.SaveChanges();
            return PartialView("StudentList", _unitOfWork.Repository<Student>().Get());
        }

        #endregion

        #region IDisposable Methods

        /// <summary>
        /// Method to dispose controller
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}