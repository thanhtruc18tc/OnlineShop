using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Base;
using Model.Dao;
using Model.EF;
using OnlineShop.Common.Constants;

namespace OnlineShop.Controllers
{
    public class CollectionController : BaseController
    {
        // GET: Collection
        public ActionResult Filter(string id, int page = 1)
        {
            var dao = new ProductDao(context);

            var categoryName = "";
            ViewBag.Page = page;
            //ViewBag.Total = dao.GetCount();
            ViewBag.FilterBy = id;
            switch (id)
            {
                case "giam-gia":
                    categoryName = Constants.Sale;
                    break;
                case "tat-ca-hang-moi":
                    categoryName = Constants.New;
                    break;
                case "hang-nam-moi":
                    categoryName = Constants.MenArrival;
                    break;
                case "hang-nu-moi":
                    categoryName = Constants.WomenArrival;
                    break;
                case "ao-so-mi-nam":
                    categoryName = Constants.MenShirt;
                    break;
                case "ao-thun-nam":
                    categoryName = Constants.MenTShirt;
                    break;
                case "ao-khoac-nam":
                    categoryName = Constants.MenJacket;
                    break;
                case "quan-dai-nam":
                    categoryName = Constants.MenTrouser;
                    break;
                case "quan-short-nam":
                    categoryName = Constants.MenShort;
                    break;
                case "tat-ca-quan-ao-nam":
                    categoryName = Constants.MenAll;
                    break;
                case "ao-kieu-nu":
                    categoryName = Constants.WomenBlouse;
                    break;
                case "ao-so-mi-nu":
                    categoryName = Constants.WomenShirt;
                    break;
                case "ao-thun-nu":
                    categoryName = Constants.WomenTShirt;
                    break;
                case "ao-khoac-nu":
                    categoryName = Constants.WomenJacket;
                    break;
                case "vay-nu":
                    categoryName = Constants.WomenDress;
                    break;
                case "quan-dai-nu":
                    categoryName = Constants.WomenTrouser;
                    break;
                case "tat-ca-quan-ao-nu":
                    categoryName = Constants.WomenAll;
                    break;
                case "giay-nam":
                    categoryName = Constants.MenShoe;
                    break;
                case "giay-nu":
                    categoryName = Constants.WomenShoe;
                    break;
                default:
                    break;

            }
            ViewBag.Total = dao.GetCount(categoryName);
            ViewBag.Title = categoryName;
            var list = dao.GetProduct(categoryName, page, pageSize);
            var listImage = GetListImage(list);
            ViewBag.ListImage = listImage;
            return View("Collection", list);
        }

        private List<Image> GetListImage(IEnumerable<Product> list)
        {
            List<Image> listImage = new List<Image>();
            var dao = new ImageDao(context);
            foreach (var item in list)
            {
                listImage.Add(dao.GetByIdProduct(item.id_product));
            }
            return listImage;
        }
    }
}