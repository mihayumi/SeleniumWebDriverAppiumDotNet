using System;
using NUnit.Framework;
using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.Common
{
    public class BaseTestWeb
    {
        [SetUp]
        public void Start()
        {
            DriverManager.StartDriverChrome();
        }

        [TearDown]
        public void Finish()
        {
            try
            {
                WebKeyWords.Instance.GetScreenShot();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao capturar o Screenshot :(");
                throw new Exception(e.Message);
            }
            finally
            {
                DriverManager.CloseDriver();
            }
        }
    }
}
