namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Packages;

    public class ExtraSize
    {
        public ExtraSize()
        {
            this.AvailablePackages = new List<PackageViewModel>();
        }

        public int Index { get; set; }

        public List<PackageViewModel> AvailablePackages { get; set; }
    }
}
