using NUnit.Framework;
using NUnitProjectPOM;
using NUnitProjectPOM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NunitProjectNonStaticDriverPOM.TestModules
{
    public class LoginTest : IDisposable
    {
        private readonly Base _base;
        private readonly HomePage _homePage;
        private readonly ElementsPage _elementsPage;
        private readonly LoginPage? _loginPage;

        public LoginTest()
        {
            _base = new Base(BrowserType.chrome);
            _base.Start();
            _homePage = new HomePage(_base.driver);
            _elementsPage = new ElementsPage(_base.driver);
            _loginPage = new LoginPage(_base.driver);
        }

        
        [Test]
        public void TextBoxTest1()
        {
            _homePage.ClickElements();
            _elementsPage.ClickTextBox();
        }

        [Test]
        public void LoginTest1()
        {
            _homePage.ClickBookStoreApplications();
            _loginPage?.ClickLogin();
            var txtValue = _loginPage?.GetLoginHeaderTxt();
             Assert.AreEqual("Welcome,\r\nLogin in Book Store", txtValue, "Values are not equal");
            Thread.Sleep(5000);
        }

        public void Dispose()
        {
            _base.driver?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
