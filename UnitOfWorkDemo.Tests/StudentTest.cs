using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using UnitOfWorkDemo.Controllers;

namespace UnitOfWorkDemo.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestListView()
        {
            var controller = new StudentsController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Test Passed", result.ViewBag.Name);
        }
    }
}
