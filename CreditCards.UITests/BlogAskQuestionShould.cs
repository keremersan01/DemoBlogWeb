using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace CreditCards.UITests
{
    public class BlogAskQuestionShould
    {
        private const string HomeUrl = "https://localhost:44303/";
        private const string askQuestionUrl = "https://localhost:44303/Home/CreateQuestion";
        private const string FirstQuestionUrl = "https://localhost:44303/Home/Question/1";

        [Fact]
        [Trait("Category","Application")]
        public void BeInitiatedFromHomePageByName_AskQuestion()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                // Using explicit wait element.

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement askQuestionButton = wait.Until((d) => d.FindElement(By.Name("askQuestionButton")));
                askQuestionButton.Click();

                //IWebElement askQuestionButton = driver.FindElement(By.Name("askQuestionButton"));
                //askQuestionButton.Click();



                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }


        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByLinkText_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.LinkText("Ask Question"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByClassName_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement questionTitle = driver.FindElement(By.ClassName("questions")); // it returns first matching question element
                questionTitle.Click();

                Assert.Equal("Question - DemoBlogWeb", driver.Title);
                Assert.Equal(FirstQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByPartialLinkText_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.PartialLinkText("uestion"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByXPath_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/a"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByRelativeXPath_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/a"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        
        [Fact]
        public void BeSubmittedWhenValid()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                // To fix Debugging "Element is not clickable at point" error
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(askQuestionUrl);

                driver.FindElement(By.Id("Question_Title")).SendKeys("SELENIUM TEST SORUSU");
                driver.FindElement(By.Id("Question_QuestionBody")).SendKeys("SELENIUM TEST SORU GÖVDESİ");
                driver.FindElement(By.Id("QuestionTag_Name")).SendKeys("TEST TAG");

                //driver.FindElement(By.Id("Question_QuestionBody")).Submit();

                driver.FindElement(By.Id("submit")).Click();

                // You can do asserts if it is necessary


            }
        }

        [Fact]
        public void BeSubmittedWhenInvalid()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // To fix Debugging "Element is not clickable at point" error
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(askQuestionUrl);

                driver.FindElement(By.Id("Question_Title")).SendKeys("");
                driver.FindElement(By.Id("Question_QuestionBody")).SendKeys("SELENIUM TEST SORU GÖVDESİ");
                driver.FindElement(By.Id("QuestionTag_Name")).SendKeys("TEST TAG");

                //driver.FindElement(By.Id("Question_QuestionBody")).Submit();

                driver.FindElement(By.Id("submit")).Click();

              //  var validationErrors = driver.FindElements(By.ClassName("text-danger field-validation-error"));

                Assert.Equal(askQuestionUrl, driver.Url);

                // fixing invalidations
                driver.FindElement(By.Id("Question_Title")).SendKeys("fixing invalidation");
                driver.FindElement(By.Id("submit")).Click();

                Assert.Equal(HomeUrl, driver.Url);


            }
        }
    }
}
