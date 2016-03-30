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

        #endregion

        #region IDisposable Methods

        /// <summary>
        /// Method to dispose controller
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if(_context != null)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}