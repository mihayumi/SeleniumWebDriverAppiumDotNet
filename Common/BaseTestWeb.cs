using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;
using SeleniumCoypuAppiumFramework.POM.ContactFormPage;

namespace SeleniumCoypuAppiumFramework.Common
{
    public class BaseTestWeb
    {
        private IServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Start()
        {
            DriverManager.StartDriverChrome();
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<IContactFormPage, ContactFormPage>();
            _serviceCollection.AddSingleton<IWebKeyWords, WebKeyWords>();
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        protected TEntity Resolve<TEntity>() 
        {
            return _serviceProvider.GetRequiredService<TEntity>();
        }

        [TearDown]
        public void Finish()
        {
            try
            {
                var webKeyWords = Resolve<IWebKeyWords>();
                webKeyWords.GetScreenShot();
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
