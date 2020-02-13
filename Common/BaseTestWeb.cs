using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.Common
{
    class BaseTestWeb
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
                WebKeywords.Instance.GetScreenShot();
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
