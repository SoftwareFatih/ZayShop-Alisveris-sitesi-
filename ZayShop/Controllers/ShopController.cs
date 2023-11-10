using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZayShop.Models.Shop;
using ZayShop.Services;

namespace ZayShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly CartServices cartServices = new CartServices();

        // GET: Shop
        public ActionResult Index(string category = null, string brand = null, int page = 1)
        {
            return View(new ShopListViewModel(category, brand, page));
        }

        public ActionResult ProductDetail(string product)
        {
            return View(new ShopDetailViewModel(product));
        }

        public string AddToCart(int pid,int qty=1)
        {
            cartServices.AddToCart(pid, qty);
            return "Ürün eklendi!!!";
        }
    }
}