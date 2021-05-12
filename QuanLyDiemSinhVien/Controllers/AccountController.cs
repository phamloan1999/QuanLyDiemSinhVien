using QuanLyDiemSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyDiemSinhVien.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        // Nhận dữ liệu từ client gửi lên
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel acc, string returnUrl)
        {
            // Nếu vượt qua được validation ở AccountModel

            var db = new QLDSVDbContext();

            var model = db.AccountModels.Where(t => t.Username == acc.Username && t.Password == acc.Password).ToList().Count();

            if (ModelState.IsValid)
            {
                if (model == 1)
                {

                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectTolocal(returnUrl);
                }
            }
            return View(acc);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        // Kiểm tra xem returnUrl có thuộc hệ thống hay không
        private ActionResult RedirectTolocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}

        
        
    
