namespace Tapas.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
