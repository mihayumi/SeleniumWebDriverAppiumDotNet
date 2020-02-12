using NUnit.Framework;
using SeleniumCoypuAppiumFramework.Common;
using SeleniumCoypuAppiumFramework.Lib;
using SeleniumCoypuAppiumFramework.Models;
using SeleniumCoypuAppiumFramework.POM.ContactFormPage;

namespace SeleniumCoypuAppiumFramework.Tests
{
    [Parallelizable(ParallelScope.All)]
    class ContactForm : BaseTest
    {
        [Test]
        [Category("Smoke")]
        //DDT - Data Driven Testing
        [TestCase("Michelee","Murai","Brazil","123adasxd")]
        [TestCase("Teste","TEste","Brazil","123adasxd")]
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

            ContactFormPage.Instance.AcessPageContractForm()
                                    .Verify()
                                        .ShouldBeHaveTitle();
            ContactFormPage.Instance.FillinFields(contactFormData)
                                    .ClickSubmit()
                                    .Verify()
                                        .ShouldBeHaveMessage();
        }
    }
}
