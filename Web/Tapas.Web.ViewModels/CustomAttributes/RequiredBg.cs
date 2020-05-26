namespace Tapas.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RequiredBg : RequiredAttribute
    {
        public RequiredBg()
        {
            this.ErrorMessage = "Полето {0} е задължително.";
        }
    }
}
