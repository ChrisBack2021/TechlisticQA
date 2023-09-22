using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Techlistic.Pages
{
    internal class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstName => driver.FindElement(By.CssSelector("input[name='firstname']"));
        public IWebElement LastName => driver.FindElement(By.CssSelector("input[name='lastname']"));
        public IWebElement GenderRadio => driver.FindElement(By.CssSelector("#sex-0"));
        public ReadOnlyCollection<IWebElement> YearsOfExp => driver.FindElements(By.CssSelector("input[name='exp']"));
        public ReadOnlyCollection<IWebElement> Profession => driver.FindElements(By.XPath("//div[@class='control-group']//input[@name='profession']"));
        public IWebElement Date => driver.FindElement(By.XPath("//input[@id='datepicker']"));
        public IWebElement Tools => driver.FindElement(By.Id("tool-2"));

        public IWebElement Continents => driver.FindElement(By.XPath("//select[@name='continents']"));

        public IWebElement SeleniumCommands => driver.FindElement(By.Id("selenium_commands"));
        public IWebElement BrowseFile => driver.FindElement(By.CssSelector("#photo"));
        public IWebElement SubmitBtn => driver.FindElement(By.Id("submit"));

        public void Submit()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView();", SubmitBtn);

            SubmitBtn.Click();
        }

        public void ChooseSelCom()
        {
            SelectElement selectSelCom = new SelectElement(SeleniumCommands);
            selectSelCom.SelectByText("Navigation Commands");
            selectSelCom.SelectByText("Wait Commands");
            
            
        }

        public void ChooseContinent()
        {
            SelectElement selectCont = new SelectElement(Continents);
            selectCont.SelectByText("Australia");
        }

        public void ToolSelect()
        {
            Tools.Click();
        }

        public string ChooseProfession()
        {
            string chosenProf = String.Empty;
            try
            {
                foreach (var prof in Profession)
                {
                    if (prof.GetAttribute("value") == "Automation Tester")
                    {
                        chosenProf = prof.GetAttribute("value");
                        prof.Click();
                        return chosenProf;
                    }
                }
                return chosenProf;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return chosenProf;
            }
            

        }

        public void EnterDate()
        {
            Date.SendKeys("15/08/2023");
        }

        public void SelectFile()
        {
            BrowseFile.SendKeys("C:\\Users\\Chris\\Desktop\\Hwiskey.PNG");
        }
    

    public string ChooseYearsOfExp()
        {
            string yearsofExp = String.Empty;
            try
            {
                foreach (var year in YearsOfExp)
                {
                    Console.WriteLine(year.GetAttribute("value"));
                    if (year.GetAttribute("value") == "1")
                        yearsofExp = year.GetAttribute("value");
                    year.Click();
                    return yearsofExp;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return yearsofExp;
        }

        public void ChooseGender()
        {
            GenderRadio.Click();
        }


        public bool LastNameEnterred()
        {
            bool flag = false;
            try
            {
                LastName.SendKeys("Test");
                if (LastName.GetAttribute("value") == "Test")
                {
                    flag = true;
                    return flag;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return flag;
            }
            return flag;
        }

        public bool NameEnterred()
        {
            bool flag = false;
            try
            {
                FirstName.SendKeys("Chris");
                if (FirstName.GetAttribute("value") == "Chris")
                {
                    flag = true;
                    return flag;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return flag;
            }
            return flag;
        }
    }
}
