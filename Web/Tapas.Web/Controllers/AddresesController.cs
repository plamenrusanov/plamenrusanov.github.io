namespace Tapas.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AddresesController : Controller
    {
        // GET: Addreses
        public ActionResult Index()
        {
            this.HttpContext.Response.Headers.Add("accept", "application/json");
            this.HttpContext.Response.Headers.Add("authorization", "apikey");
            return this.View();
        }

        // GET: Addreses/Details/5
        public ActionResult Add()
        {
            return this.View();
        }

        // GET: Addreses/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Addreses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Addreses/Edit/5
        public ActionResult AddCopy()
        {
            return this.View();
        }

        // POST: Addreses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Addreses/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Addreses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
