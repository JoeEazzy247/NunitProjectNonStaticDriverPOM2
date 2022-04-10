using NUnitProjectPOM.utilities;
using OpenQA.Selenium;

namespace NUnitProjectPOM.PageObjects
{
    public class LoginPage 
    {
        readonly IWebDriver? _driver;
        public LoginPage(IWebDriver? driver)
        {
            _driver = driver;
        }

        #region 
        //Property
        static By Login => By.XPath("(//li[@id='item-0'])[6]");
        static By LoginheaderTxt => By.XPath("(//form[@id='userForm']/div)[1]");

        #endregion



        public void ClickLogin()
        {
            IWebElement? login = _driver?.FindElement(Login);
            login?.ScrollIntoViewViaJs(_driver);
            login?.ClickViaJs(_driver);
        }

        public string? GetLoginHeaderTxt() => _driver?.FindElement(LoginheaderTxt).Text;
    }
}
