using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinhDGT_Electronic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "chitietsanpham",
                url: "sanpham/chitietsanpham/{sanphamid}",
                defaults: new { controller = "SanPham", action = "chitietsanpham", sanphamid = UrlParameter.Optional },
                namespaces: new[] { "LinhDGT_Electronic.Controllers" }
            );
            routes.MapRoute(
               name: "giohang",
               url: "giohang",
               defaults: new { controller = "GioHang", action = "index", id = UrlParameter.Optional },
               namespaces: new[] { "LinhDGT_Electronic.Controllers" }
           );
            routes.MapRoute(
              name: "xoanhieu",
              url: "giohang/xoanhieu/{ids}",
              defaults: new { controller = "GioHang", action = "index", ids = UrlParameter.Optional },
              namespaces: new[] { "LinhDGT_Electronic.Controllers" }
          );
            routes.MapRoute(
                name: "chitietsanphamtheodanhmuc",
                url: "sanpham/chitietsanphamtheodanhmuc/{danhmucid}/{sanphamid}",
                defaults: new { controller = "SanPham", action = "chitietsanphamtheodanhmuc", danhmucid = UrlParameter.Optional, sanphamid = UrlParameter.Optional },
                namespaces: new[] { "LinhDGT_Electronic.Controllers" }
            );
            routes.MapRoute(
                name: "sanphamtheodanhmuc",
                url: "sanpham/sanphamtheodanhmuc/{danhmucid}",
                defaults: new { controller = "SanPham", action = "sanphamtheodanhmuc", danhmucid = UrlParameter.Optional },
                namespaces: new[] { "LinhDGT_Electronic.Controllers" }
            );
            routes.MapRoute(
               name: "chitietsanphamtheothuonghieu",
               url: "sanpham/chitietsanphamtheothuonghieu/{thuonghieuid}/{sanphamid}",
               defaults: new { controller = "SanPham", action = "chitietsanphamtheothuonghieu", thuonghieuid = UrlParameter.Optional, sanphamid = UrlParameter.Optional },
               namespaces: new[] { "LinhDGT_Electronic.Controllers" }
           );
            routes.MapRoute(
                name: "sanphamtheothuonghieu",
                url: "sanpham/sanphamtheothuonghieu/{thuonghieuid}",
                defaults: new { controller = "SanPham", action = "sanphamtheothuonghieu", thuonghieuid = UrlParameter.Optional },
                namespaces: new[] { "LinhDGT_Electronic.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "LinhDGT_Electronic.Controllers" }
            );
        }
    }
}
