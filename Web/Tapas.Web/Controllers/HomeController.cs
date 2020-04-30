namespace Tapas.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
        private readonly IProductsService productsService;
        private readonly IGeolocationService geolocationService;

        public HomeController(IHomeService homeService, IProductsService productsService, IGeolocationService geolocationService)
        {
            this.homeService = homeService;
            this.productsService = productsService;
            this.geolocationService = geolocationService;
        }

        public IActionResult Index()
        {
            return this.View();
        }


        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
