using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;
using SeleniumCoypuAppiumFramework.Common;
using SeleniumCoypuAppiumFramework.Lib;
using SeleniumCoypuAppiumFramework.Models;
using SeleniumCoypuAppiumFramework.POM.ContactFormPage;

namespace SeleniumCoypuAppiumFramework.Tests
{
    [Parallelizable(ParallelScope.All)]
    class ContactForm : BaseTestWeb
    {
        [SetUp]
        public void Test()
        {
            DriverManager.GetDriver<IWebDriver>()
                .Navigate()
                .GoToUrl("https://demoqa.com");
        }

        [Test]
        [Category("Smoke")]
        //DDT - Data Driven Testing
        [TestCase("Michelee", "Murai", "Brazil", "123adasxd")]
        [TestCase("Teste", "TEste", "Brazil", "123adasxd")]
        [TestCase("Teste2", "TsEste", "Brazil", "12a3adasxd")]
        public void ShouldContractSucess(string firstName, string lastName, string country, string subject)
        {
            var contactFormData = new ContactFormModel()
            {
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                Subject = subject
            };

            DataBase.RemoveDataBeforeTest(firstName, lastName);
            
            var contactPage = Resolve<IContactFormPage>();

            contactPage
                .AcessPageContractForm()
                .FillinFields(contactFormData)
                .ClickSubmit();

            Assert.AreEqual("Oops! That page can’t be found.", contactPage.GetTextResult());
        }
    }
}
