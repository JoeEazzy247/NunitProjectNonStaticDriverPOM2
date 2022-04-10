﻿using NUnit.Framework;
using NUnitProjectPOM;
using NUnitProjectPOM.PageObjects;
using System;
using System.Threading;

namespace NunitProjectNonStaticDriverPOM.TestModules
{
    public class LoginTest : Base
    {
        private readonly HomePage _homePage;
        private readonly ElementsPage _elementsPage;
        private readonly LoginPage? _loginPage;

        public LoginTest()
        {
            _homePage = new HomePage(GetDriver());
            _elementsPage = new ElementsPage(GetDriver());
            _loginPage = new LoginPage(GetDriver());
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
    }
}
