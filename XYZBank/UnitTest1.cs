using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Techlistic.Pages;


namespace Techlistic
{
    public class Tests
    {
        public IWebDriver driver;
        string url = "https://www.techlistic.com/p/selenium-practice-form.html";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void Test1()
        {
            MainPage mPage = new MainPage(driver);
            bool correctName = mPage.NameEnterred();
            Assert.That(correctName, Is.True, "First name is not inputted correctly.");

            bool correctLastName = mPage.LastNameEnterred();
            Assert.That(correctLastName, Is.True, "Correct surname has not been inputted.");

            mPage.ChooseGender();
            string expYears = mPage.ChooseYearsOfExp();
            Assert.That(expYears, Is.EqualTo("1"), "Experience years should be 1.");

            mPage.EnterDate();

            string profession = mPage.ChooseProfession();
            Assert.That(profession, Is.EqualTo("Automation Tester"), "Automation Tester profession should be selected.");

            mPage.ToolSelect();
            mPage.ChooseContinent();
            mPage.ChooseSelCom();
            mPage.SelectFile();
            mPage.Submit();
        }

        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}