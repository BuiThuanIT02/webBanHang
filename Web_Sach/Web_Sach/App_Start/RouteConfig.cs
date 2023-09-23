using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Sach
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });


            routes.MapRoute(
             name: "Chi tiết sản phẩm",
             url: "chi-tiet/{metatilte}-{detailId}",
             defaults: new { controller = "Product", action = "Product", id = UrlParameter.Optional },
             namespaces: new[] { "Web_Sach.Controllers" }

         );
            routes.MapRoute(
            name: "Giới thiệu ",
            url: "gioi-thieu",
            defaults: new { controller = "Introduce", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Web_Sach.Controllers" }

        );
            routes.MapRoute(
            name: "Chi tiết tin tức ",
            url: "tin-tuc/{metatilte}-{newID}",
            defaults: new { controller = "Introduce", action = "NewDetail", id = UrlParameter.Optional },
            namespaces: new[] { "Web_Sach.Controllers" }

        );
            routes.MapRoute(
           name: "Tác giả",
           url: "tac-gia/{authorID}",
           defaults: new { controller = "Author", action = "Info", id = UrlParameter.Optional },
           namespaces: new[] { "Web_Sach.Controllers" }

       );
            routes.MapRoute(
           name: "Tin tức ",
           url: "tin-tuc",
           defaults: new { controller = "Introduce", action = "News", id = UrlParameter.Optional },
           namespaces: new[] { "Web_Sach.Controllers" }

       );


            routes.MapRoute(
              name: "Danh mục sản phẩm",
              url: "san-pham/{metatilte}-{cateId}",
              defaults: new { controller = "ProductCategory", action = "ProductCategory", id = UrlParameter.Optional },
              namespaces: new[] { "Web_Sach.Controllers" }

          );


            routes.MapRoute(
              name: "Cập nhật thông tin người dùng",
              url: "cap-nhat-thong-tin/{userId}",
              defaults: new { controller = "User", action = "UpdateInfo", id = UrlParameter.Optional },
              namespaces: new[] { "Web_Sach.Controllers" }

          );

            routes.MapRoute(
            name: "Thêm giỏ hàng",
            url: "them-gio-hang",
            defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional },
            namespaces: new[] { "Web_Sach.Controllers" }

        );
            routes.MapRoute(
         name: "Giỏ hàng",
         url: "gio-hang",
         defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "Web_Sach.Controllers" }

     );
            routes.MapRoute(
        name: "Thanh toan",
        url: "thanh-toan",
        defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
        namespaces: new[] { "Web_Sach.Controllers" }

    );
            routes.MapRoute(
       name: "Liên hệ",
       url: "lien-he",
       defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "Web_Sach.Controllers" }

   );

            routes.MapRoute(
       name: "Thanh toán thành công",
       url: "hoan-thanh",
       defaults: new { controller = "Cart", action = "Order", id = UrlParameter.Optional },
       namespaces: new[] { "Web_Sach.Controllers" }

   );

            routes.MapRoute(
     name: "Đăng ký",
     url: "dang-ky",
     defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
     namespaces: new[] { "Web_Sach.Controllers" }

 );
            routes.MapRoute(
     name: "Tìm kiếm",
     url: "tim-kiem",
     defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
     namespaces: new[] { "Web_Sach.Controllers" }

 );

            routes.MapRoute(
     name: "Mua ngay",
     url: "mua-ngay",
     defaults: new { controller = "Cart", action = "BuyNow", id = UrlParameter.Optional },
     namespaces: new[] { "Web_Sach.Controllers" }

 );


            routes.MapRoute(
     name: "Đăng nhập",
     url: "dang-nhap",
     defaults: new { controller = "User", action = "LoignClients", id = UrlParameter.Optional },
     namespaces: new[] { "Web_Sach.Controllers" }

 );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Web_Sach.Controllers" }
                
            );
        }
    }
}
