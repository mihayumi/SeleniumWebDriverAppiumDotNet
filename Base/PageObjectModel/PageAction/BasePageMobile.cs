using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageValidation;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageAction
{
    public class BasePageMobile<Singleton, MobileElement, Validate> : PageInstance<Singleton>
        where MobileElement : BaseMobileElements, new()
        where Validate : BaseMobileValidation<MobileElement>, new()
        where Singleton : BasePageMobile<Singleton, MobileElement, Validate>, new()
    {
        public BasePageMobile()
        {
        }
        protected MobileElement Element
        {
            get
            {
                return new MobileElement();
            }
        }
        public Validate Verify()
        {
            return new Validate();
        }
    }
}
