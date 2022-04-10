using OpenQA.Selenium;

namespace NUnitProjectPOM.PageObjects
{
    public class ElementsPage 
    {
        readonly IWebDriver? _driver;
        public ElementsPage(IWebDriver? driver)
        {
            this._driver = driver;
        }

        #region 
        //Property
        static By TextBox => By.Id("item-0");

        #endregion



        public void ClickTextBox() =>
            _driver?.FindElement(TextBox).Click();
    }
}
