using System;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageAction
{
    public abstract class PageInstance<PageObject>
    where PageObject : new()
    {
        private static readonly Lazy<PageObject> _instance = new Lazy<PageObject>(() => new PageObject());

        public static PageObject Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
