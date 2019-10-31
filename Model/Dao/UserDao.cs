using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Dao
{
    public class UserDao

    {
        OnlineShopContext db = null;

        public object Encryptor { get; private set; }

        public UserDao(OnlineShopContext context)
        {
            db = context;
        }

        public void test()
        {
            if (db.UserTypes.Count() == 0)
            {
                db.UserTypes.Add(new UserType { name = "Silver" });
                db.UserTypes.Add(new UserType { name = "Gold" });
                db.SaveChanges();
            }

            if (db.Users.Count() == 0)
            {
                db.Users.Add(new User("test", "202cb962ac59075b964b07152d234b70", "tructran25.98@gmail.com", "Truc Tran", "0981777309", "Quận 4", 1, false, true));
                db.Users.Add(new User("admin", "202cb962ac59075b964b07152d234b70", "admin@gmail.com", "Admin", "0981777309", "Quận 4", 1, true, true));
                db.SaveChanges();
            }

            if (db.Categories.Count() == 0)
            {
                db.Categories.Add(new Category { name = "Áo sơ mi nam" });
                db.Categories.Add(new Category { name = "Áo thun nam" });
                db.Categories.Add(new Category { name = "Áo khoác nam" });
                db.Categories.Add(new Category { name = "Quần dài nam" });
                db.Categories.Add(new Category { name = "Quần short nam" });
                db.Categories.Add(new Category { name = "Áo kiểu nữ" });
                db.Categories.Add(new Category { name = "Áo sơ mi nữ" });
                db.Categories.Add(new Category { name = "Áo thun nữ" });
                db.Categories.Add(new Category { name = "Áo khoác nữ" });
                db.Categories.Add(new Category { name = "Váy nữ" });
                db.Categories.Add(new Category { name = "Quần dài nữ" });
                db.Categories.Add(new Category { name = "Giày nam" });
                db.Categories.Add(new Category { name = "Giày nữ" });
                db.SaveChanges();
            }

            if (db.Sizes.Count() == 0)
            {
                db.Sizes.Add(new Size { name = "S"});
                db.Sizes.Add(new Size { name = "M" });
                db.Sizes.Add(new Size { name = "L" });
                db.Sizes.Add(new Size { name = "25" });
                db.Sizes.Add(new Size { name = "26" });
                db.Sizes.Add(new Size { name = "27" });
                db.Sizes.Add(new Size { name = "28" });
                db.Sizes.Add(new Size { name = "29" });
                db.Sizes.Add(new Size { name = "30" });
                db.Sizes.Add(new Size { name = "31" });
                db.Sizes.Add(new Size { name = "32" });
                db.Sizes.Add(new Size { name = "33" });
                db.Sizes.Add(new Size { name = "34" });
                db.Sizes.Add(new Size { name = "35" });
                db.Sizes.Add(new Size { name = "36" });
                db.Sizes.Add(new Size { name = "37" });
                db.Sizes.Add(new Size { name = "38" });
                db.Sizes.Add(new Size { name = "39" });
                db.Sizes.Add(new Size { name = "40" });
                db.Sizes.Add(new Size { name = "41" });
                db.Sizes.Add(new Size { name = "42" });
                db.SaveChanges();
            }

            if (db.Colors.Count() == 0)
            {
                db.Colors.Add(new Color { name = "Trắng" });
                db.Colors.Add(new Color { name = "Đen" });
                db.Colors.Add(new Color { name = "Vàng" });

                db.SaveChanges();
            }

            if (db.Products.Count() == 0)
            {
                db.Products.Add(new Product { name = "Áo sơ mi nam NOLAN", id_category = 1, description = "Chẳng biết từ bao giờ áo sơ mi đã trở thành trang phục bất hủ của mọi đấng mày râu trên thế giới. Hình ảnh một người đàn ông mặc sơ mi dường như đã gắn liền với chuẩn mực lịch lãm của phái mạnh. Vậy còn những chiếc sơ mi cách điệu như Nolan Shirt của The Cosmo thì như thế nào? Chắc chắn đây sẽ là một item chàng cần sở hữu vì độ độc đáo, ấn tượng bởi thiết kế vạt đắp và một nút cài duy nhất. Thiết kế này không chỉ mang lại cho phái mạnh vẻ đẹp thời thượng của các fashionista trên thế giới mà còn giúp bạn khoe khéo những đường cong cơ bắp đầy quyến rũ.Không chỉ phù hợp với vẻ lịch lãm của những chiếc quần chinos, bạn còn có thể thử phối áo cùng shorts cho phong cách thời trang trẻ trung và phóng khoáng hơn.", price = 530000, promotionPrice = null, dateCreate = DateTime.Now  });
                db.Products.Add(new Product { name = "Áo sơ mi nam JACOB", id_category = 1, description = "Đối với khí hậu nhiệt đới ở Việt Nam, những chiếc áo sơ mi làm từ chất liệu vải thiên như cotton luôn là lựa chọn hoàn hảo cho các chàng trai. Vì những mẫu áo như Jacob Shirt này thì bên cạnh vẻ lịch lãm, nam tính thường thấy, còn đảm bảo sự thấm hút mồ hôi liên tục, lại không hề gây khó chịu cho làn da của phái mạnh. Áo có thiết kế cổ trụ, tay dài, phom suông, chất vải 100 % cotton mỏng nhẹ và siêu thoáng mát.Nếu đã quá quen thuộc với sự kết hợp của bộ đôi hoàn hảo sơ mi - quần tây lịch lãm hay sơ mi - jeans dài phóng khoáng, sao bạn không thử kết hợp cùng quần chinos xắn gấu và sơ vin áo theo phong cách vạt high - low cho phong cách thời trang mới mẻ và trẻ trung hơn ? ", price = 469000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo thun nam RAFAEL POLO", id_category = 2, description = "Có thể nói, áo thun polo là sự kết hợp hoàn hảo giữa áo thun và cổ áo sơ mi để mang đến cho các quý ông vừa cần đến vẻ ngoài thoải mái nhưng vẫn muốn thể hiện phong cách thời trang lịch lãm và chỉn chu. Vì thế, không khỏi ngạc nhiên khi từ lâu đời, áo thun polo đã trở thành item không thể thiếu trong tủ quần áo của phái mạnh, bên cạnh những chiếc áo thun trơn cổ tròn và những chiếc sơ mi tay dài lịch lãm. Rafael Polo Shirt được may từ chất liệu 100 % cotton cao cấp, đảm bảo sự thấm hút mồ hôi tối đa cho chàng thêm tự tin trong các hoạt động hàng ngày.Áo có bảng màu trẻ trung, đa dạng, không kén dáng và phù hợp với mọi màu da, cho phái mạnh thêm nhiều lựa chọn với jeans hoặc khaki khi đến công sở hay chỉ đơn giản mix cùng shorts năng động cho những buổi dạo phố cùng bạn bè.", price = 249000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo thun nam LIBERTY TEE", id_category = 2, description = "Liệu còn item nào trong thế giới thời trang của phái mạnh thông dụng hơn những chiếc áo thun trơn cổ tròn? Và Liberty Tee chính là một item như thế. Không cầu kỳ với những chi tiết nhấn nhá điệu đà, Liberty Tee chỉ đơn giản là áo thun trơn cổ tròn, phom suông, dáng basic mà bất kỳ chàng trai nào cũng nên sở hữu ít nhất một chiếc trong tủ quần áo của mình. Áo thun cổ tròn, tay ngắn, được may từ chất liệu 100 % cotton mang đến độ thấm hút mồ hôi tuyệt đối và cảm giác thoải mái, thoáng mát để các chàng thỏa thích vận động suốt cả ngày.Áo thun trơn là item không kén dáng, nên phái mạnh có thể tùy thích kết hợp cùng jeans dài, shorts cho phong cách thời trang năng động, hay thậm chí là phối cùng suits và sneakers để tạo dáng vẻ lịch lãm nhưng cũng không kém phần trẻ trung và thời thượng.", price = 580000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo thun nam SOMERSET", id_category = 2, description = "Áo thun cổ tròn, tay ngắn, phom suông, họa tiết kẻ sọc trendy, kiểu dáng basic, dễ dàng mix cùng nhiều màu sắc trang phục khác, cho bạn phong cách thời trang năng động đầy cá tính.", price = 200000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo khoác nam TONY JACKET", id_category = 3, description = "Một chiếc áo khoác nam phong cách không chỉ giúp giữ ấm cơ thể, mà còn giúp tạo điểm nhấn cho tổng thể trang phục của bạn trông hoàn hảo hơn bao giờ hết. Và Tony Jacket được The Cosmo cho ra đời với sứ mệnh như thế! Áo khoác khaki tay dài, có nón, phối dây kéo kim loại và bốn túi to tạo điểm nhấn ở thân trước.Áo thiết kế dây rút ngang eo để bạn tùy chỉnh phom áo, mang đến nhiều phong cách thời trang khác nhau bên cạnh chức năng chính là giữ ấm và chống nắng.", price = 549000, promotionPrice = 500000, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo khoác nam HYUN HANBOK", id_category = 3, description = "Nếu như Hideki Kimono lấy cảm hứng từ trang phục truyền thống của xứ sở hoa anh đào, thì Huyn Hanbok lại lấy cảm hứng từ quốc phục của đất nước Hàn Quốc xinh đẹp. Được lấy cảm hứng và thiết kế riêng cho khu vực Châu Á, thế nên mẫu áo khoác Huyn Hanbok như được đo ni đóng giày cho các chàng trai Việt yêu thích sự phá cách và muốn khẳng định cá tính riêng giữa đám đông.", price = 396000, promotionPrice = null, dateCreate = DateTime.Now });

                db.Products.Add(new Product { name = "Quần nam GEAYDEN CHINOS", id_category = 4, description = "Quần dài khaki, ống đứng, phom skinny tôn dáng, phối nút kim loại, dây kéo và hai túi ở thân trước. Với ba màu xanh navy, xanh rêu và da bò, quần Grayden thích hợp để phối với sơ mi để có một vẻ ngoài chỉnh chu và lịch sự. Bạn cũng có thể phối quần chinos với áo thun khi đi chơi theo phong cách tối giản, trẻ trung, và năng động.Quần Grayden được may trên chất liệu vải khaki mềm có độ co giãn nhẹ, mang đến cho bạn sự thoải mái tối đa trong hoạt động hàng ngày.", price = 499000, promotionPrice = 399000, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Quần nam GEAYDEN CHINOS", id_category = 4, description = "Quần dài khaki, ống đứng, phom skinny tôn dáng, phối nút kim loại, dây kéo và hai túi ở thân trước. Với ba màu xanh navy, xanh rêu và da bò, quần Grayden thích hợp để phối với sơ mi để có một vẻ ngoài chỉnh chu và lịch sự. Bạn cũng có thể phối quần chinos với áo thun khi đi chơi theo phong cách tối giản, trẻ trung, và năng động.Quần Grayden được may trên chất liệu vải khaki mềm có độ co giãn nhẹ, mang đến cho bạn sự thoải mái tối đa trong hoạt động hàng ngày.", price = 499000, promotionPrice = 399000, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Quần nam SANDBOURND SHORTS", id_category = 5, description = "Nếu như Alex Shorts của The Cosmo mang đến cho bạn phong cách trẻ trung, năng động nhưng cũng vô cùng lịch lãm nhờ chi tiết phom quần hơi ôm và tôn dáng, thì Sanbourne Shorts lại mang đến cho phái mạnh sức sống trẻ trung, phóng khoáng và thoải mái hơn nhờ vào thiết kế phom quần suông rộng. Nếu bạn đang tìm kiếm một mẫu quần shorts thoải mái, nhưng lại không thích sự đơn giản đến xuề xòa của quần thun, thì Sanbourne Shorts đích thị là item mà bạn đang tìm kiếm. Mẫu quần có phom suông, hai túi bên hông và hai túi ở thân sau, chiều dài ngắn trên gối, phù hợp cho các hoạt động thể chất và phong cách thời trang năng động.Bạn không chỉ có thể kết hợp quần cùng áo thun polo hay áo thun trơn, mà mẫu quần cũng rất hợp khi mix cùng sơ mi hoặc blazer lịch lãm.", price = 399000, promotionPrice = 99000, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Quần nam ALEX SHORTS", id_category = 5, description = "Mùa hè là thời điểm thích hợp để những item năng động, thoải mái như quần shorts lên ngôi, và The Cosmo xin giới thiệu đến bạn mẫu Alex Shorts, giải pháp giải phóng sự bí bách cho đôi chân của bạn vào những ngày thời tiết ẩm ương sáng nắng chiều mưa. Mẫu quần có phom ôm vừa phải, hai túi bên hông và hai túi ở thân sau, chiều dài ngắn trên gối, phù hợp cho các hoạt động thể chất và phong cách thời trang năng động.Bạn không chỉ có thể kết hợp quần cùng áo thun polo hay áo thun trơn, mà mẫu quần cũng rất hợp khi mix cùng sơ mi hoặc blazer lịch lãm.", price = 399000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Giày Dr. Marten Mono Black", id_category = 12, description = "Dr. Martens là thương hiệu giày dép truyền thống của Anh, ra đời từ những năm đầu của thế kỷ 20. Thương hiệu trải qua gần 60 năm tồn tại như là biểu tượng của “sự phá cách” và gắn liền với tinh thần của cả một thời kỳ. Kế thừa một thương hiệu nổi tiếng, các sản phẩm đã được ứng dụng như là những sự lựa chọn trong văn hoá thời trang hơn 40 năm qua và sẽ còn tiếp tục phát triển mạnh mẽ hơn nữa.Dr.Martens bán những sản phẩm giày dép có chất lượng cao của mình rất tốt trên toàn thế giới với những nét đặc trưng riêng, mang phong cách cổ điển và sự khéo léo trong từng sản phẩm", price = 4000000, promotionPrice = 3590000, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Giày Dr. Marten Unisex Trullia", id_category = 12, description = "Dr. Martens là thương hiệu giày dép truyền thống của Anh, ra đời từ những năm đầu của thế kỷ 20. Thương hiệu trải qua gần 60 năm tồn tại như là biểu tượng của “sự phá cách” và gắn liền với tinh thần của cả một thời kỳ. Kế thừa một thương hiệu nổi tiếng, các sản phẩm đã được ứng dụng như là những sự lựa chọn trong văn hoá thời trang hơn 40 năm qua và sẽ còn tiếp tục phát triển mạnh mẽ hơn nữa.Dr.Martens bán những sản phẩm giày dép có chất lượng cao của mình rất tốt trên toàn thế giới với những nét đặc trưng riêng, mang phong cách cổ điển và sự khéo léo trong từng sản phẩm", price = 3990000, promotionPrice = null, dateCreate = DateTime.Now });

                //db.Products.Add(new Product { name = "", id_category = 4, description = "", price = 499000, promotionPrice = 399000, dateCreate = DateTime.Now });



                db.SaveChanges();
            }

            if (db.Images.Count() == 0)
            {
                db.Images.Add(new Image { id_product = 1, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_22089bl6_afd44fdfce2948849a8863fd3bf59320_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 1, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_22089bl5_76a65286968e49108251e2f676e5644e_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 1, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_22089bl3_5939ca06e39c4fd99a53fc606a337fd8_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 1, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_22089bl4_3353f47144cf4dcfa4067f4bb4a13a9d_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 2, link = "https://product.hstatic.net/1000289385/product/mausac-xanhreu_22088ms1_84fded0ef78d491ba1f2cca0c7eb2ed8_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 2, link = "https://product.hstatic.net/1000289385/product/mausac-xanhreu_22088ms3_eae4ffd5b3d44ed18010da68ef4669bd_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 2, link = "https://product.hstatic.net/1000289385/product/mausac-xanhreu_22088ms5_f79fdf36401f479999f9b5dc1c64f6c6_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 2, link = "https://product.hstatic.net/1000289385/product/mausac-xanhreu_22088ms6_a360ab2bd57e433581673e1519d559a9_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 3, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_21074na1_0eb18a6a237046b2a1bf907181a7fde1_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 3, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_21074na6_a0a448d1ae2943fb9ffb4d3353ee1d6d_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 3, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_21074na3_23eb554c4d0a42fb96a1e677eba4a148_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 3, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_21074na5_b584c748386e4eba9ffdad01e675f161_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 4, link = "https://product.hstatic.net/1000289385/product/mausac-trang_21064r1wh4_294089c2a9334afba43318979d39c194_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 4, link = "https://product.hstatic.net/1000289385/product/mausac-trang_21064r1wh2_51359aa4c45344ea8597d9fbf4aef74f_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 4, link = "https://product.hstatic.net/1000289385/product/mausac-trang_21064r1wh5_45a1c50666584ffe8d7ef4208bb3c203_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 4, link = "https://product.hstatic.net/1000289385/product/mausac-trang_21064r1wh1_e5ec2c371942449d9d98d31bf4b5d869_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 5, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_21072bl6_3b9de4bbda444d0b8a616cfe3c9d1d99_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 5, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_21072bl1_69b74973d104426487130a280c3ecff9_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 5, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_21072bl2_d3b6e675bd424368a38cb5309b44b236_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 5, link = "https://product.hstatic.net/1000289385/product/mausac-xanh_21072bl3_6a03fb48927847c5800f6addeacd7c3e_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 6, link = "https://product.hstatic.net/1000289385/product/mausac-den_23050ba6_5dd2415978854296884fd2407893b63e_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 6, link = "https://product.hstatic.net/1000289385/product/mausac-den_23050ba5_21da5f1e8fe34e4c83911561ddee5492_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 6, link = "https://product.hstatic.net/1000289385/product/mausac-den_23050ba4_8076bdf3d9494ea9bd0fb46e5f5e5626_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 6, link = "https://product.hstatic.net/1000289385/product/mausac-den_23050ba2_dfa3de5d21384fce970f0d7afcdb2a0c_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 7, link = "https://product.hstatic.net/1000289385/product/mausac-xamdam_23052dg2_4e878d728d154790b5736bf700bfde39_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 7, link = "https://product.hstatic.net/1000289385/product/mausac-xamdam_23052dg1_52fb03d0917c4295a6cf350f0757cd57_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 7, link = "https://product.hstatic.net/1000289385/product/mausac-xamdam_23052dg6_16408d33b1cc426ea22cb5184c7c6437_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 7, link = "https://product.hstatic.net/1000289385/product/mausac-xamdam_23052dg5_3e6739d8bd404921be816e6181aa2330_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 8, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_27015na6_f98f7ecacb2b49b1bd756ae7dbeee276_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 8, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_27015na2_d27a5f23b12d48c18e7512b2dc5c3685_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 8, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_27015na3_6a3655607fce46ae8ccd5d308e949778_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 8, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_27015na1_ac98b186112842fd980172b0759d86de_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 9, link = "https://product.hstatic.net/1000289385/product/mausac-nau_27015br6_702835d7c9864e83a79071600e5dcb43_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 9, link = "https://product.hstatic.net/1000289385/product/mausac-nau_27015br3_8be3592ab940437980c92a9012e52200_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 9, link = "https://product.hstatic.net/1000289385/product/mausac-nau_27015br1_1adeef4f7deb448b837a234c236e6cee_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 9, link = "https://product.hstatic.net/1000289385/product/mausac-nau_27015br2_65d7759cbe844eab87bfb558da35ebd5_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 10, link = "https://product.hstatic.net/1000289385/product/mausac-xam_25022gr1_4efbe4d35ed340588c12ed9beffa1c5a_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 10, link = "https://product.hstatic.net/1000289385/product/mausac-xam_25022gr4_62af570f208149f1a768626829b0f8dd_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 10, link = "https://product.hstatic.net/1000289385/product/mausac-xam_25022gr2_16e314bcd98041ac84171af05df32183_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 10, link = "https://product.hstatic.net/1000289385/product/mausac-xam_25022gr3_72de7006d5b14131a51c02bfd3692be4_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 11, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_25021na1_21847bb027884f91be45fe08a25dda39_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 11, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_25021na6_9dd1915839744fe88fed8101074ad1bf_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 11, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_25021na3_4c9dbc56eb564066ba63a3b4c01e2bf0_1024x1024.jpg" });
                db.Images.Add(new Image { id_product = 11, link = "https://product.hstatic.net/1000289385/product/mausac-xanhnavy_25021na5_625a3db387424d4983042641a4b350ce_1024x1024.jpg" });

                db.Images.Add(new Image { id_product = 12, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/299/hp_1461_mono_blk_s12_1_2.jpg" });
                db.Images.Add(new Image { id_product = 12, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/299/hp_1461_mono_blk_s12_2.jpg" });
                db.Images.Add(new Image { id_product = 12, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/299/hp_1461_mono_blk_s12_7.jpg" });
                db.Images.Add(new Image { id_product = 12, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/299/hp_1461_mono_blk_s12_4.jpg" });

                db.Images.Add(new Image { id_product = 13, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/414/23372600-_1_.jpg" });
                db.Images.Add(new Image { id_product = 13, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/414/23372600.b.jpg" });
                db.Images.Add(new Image { id_product = 13, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/414/23372600_5_.jpg" });
                db.Images.Add(new Image { id_product = 13, link = "https://hoang-phuc.com/images/thumbnails/500/500/detailed/414/23372600.r.jpg" });

                //db.Images.Add(new Image { id_product = 7, link = "" });
                //db.Images.Add(new Image { id_product = 7, link = "" });
                //db.Images.Add(new Image { id_product = 7, link = "" });
                //db.Images.Add(new Image { id_product = 7, link = "" });
                db.SaveChanges();
            }

            if (db.SizeDetails.Count() == 0)
            {
                db.SizeDetails.Add(new SizeDetail { id_size = 1, id_product = 1, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 2, id_product = 1, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 3, id_product = 1, quantity = 10 });

                db.SizeDetails.Add(new SizeDetail { id_size = 1, id_product = 2});
                db.SizeDetails.Add(new SizeDetail { id_size = 2, id_product = 2});

                db.SizeDetails.Add(new SizeDetail { id_size = 3, id_product = 3, quantity = 1 });

                db.SizeDetails.Add(new SizeDetail { id_size = 1, id_product = 4, quantity = 1 });
                db.SizeDetails.Add(new SizeDetail { id_size = 2, id_product = 4, quantity = 4 });
                db.SizeDetails.Add(new SizeDetail { id_size = 3, id_product = 4, quantity = 1 });

                db.SizeDetails.Add(new SizeDetail { id_size = 2, id_product = 5});
                db.SizeDetails.Add(new SizeDetail { id_size = 3, id_product = 5});

                db.SizeDetails.Add(new SizeDetail { id_size = 1, id_product = 6, quantity = 5 });

                db.SizeDetails.Add(new SizeDetail { id_size = 1, id_product = 7, quantity = 1 });
                db.SizeDetails.Add(new SizeDetail { id_size = 3, id_product = 7, quantity = 1 });

                db.SizeDetails.Add(new SizeDetail { id_size = 9, id_product = 8, quantity = 10 });// 30
                db.SizeDetails.Add(new SizeDetail { id_size = 10, id_product = 8, quantity = 10 });// 31
                db.SizeDetails.Add(new SizeDetail { id_size = 11, id_product = 8, quantity = 10 });// 32
            
                db.SizeDetails.Add(new SizeDetail { id_size = 8, id_product = 9, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 9, id_product = 9, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 10, id_product = 9, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 11, id_product = 9, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 12, id_product = 9, quantity = 10 });

                db.SizeDetails.Add(new SizeDetail { id_size = 8, id_product = 10, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 11, id_product = 10, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 14, id_product = 10, quantity = 10 });

                db.SizeDetails.Add(new SizeDetail { id_size = 10, id_product = 11, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 12, id_product = 11, quantity = 10 });

                db.SizeDetails.Add(new SizeDetail { id_size = 19, id_product = 12, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 20, id_product = 12, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 21, id_product = 12, quantity = 10 });

                db.SizeDetails.Add(new SizeDetail { id_size = 18, id_product = 13, quantity = 10 });
                db.SizeDetails.Add(new SizeDetail { id_size = 19, id_product = 13, quantity = 1 });

                db.SaveChanges();
            }

        }


        public User GetByEmail(string email)
        {
            return db.Users.SingleOrDefault(x => x.email == email);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return db.Users.SingleOrDefault(x => x.username == username && x.password == password);
        }

        public User GetById(int id)
        {
            return db.Users.SingleOrDefault(x => x.id_user == id);
        }

        public User GetByUserName(string username)
        {
            return db.Users.SingleOrDefault(x => x.username == username);
        }

        public bool IsEmailExisted(string email)
        {
            return db.Users.Count(x => x.email == email) != 0;
        }

        // MARK: Register
        public void Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        // MARK: Lock account
        public bool ChangeStatus(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                user.isActive = !user.isActive;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // MARK: Forgot password
        public bool ChangePassword(string email, string newpass)
        {
            var user = GetByEmail(email);
            if (user != null) {
                user.password = newpass;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // MARK: Update profile
        public User Update(string id, string name, string username, string email, string address, string phone)
        {
            var user = GetById(Convert.ToInt32(id));

            user.name = name;
            user.username = username;
            user.email = email;
            user.address = address;
            user.phone = phone;
            db.SaveChanges();
            return user;

        }

        // MARK: Change password
        public void ChangePassword(int id, string newPass)
        {
            var user = GetById(id);
            user.password = newPass;
            db.SaveChanges();
        }

        // MARK: Login
        public int Login(string username, string password)
        {
            var result = db.Users.Count(x => x.username == username);
            if (result > 0)
            {
                result = db.Users.Count(x => x.username == username && x.password == password);
                if (result > 0)
                {
                    return 1; // Success
                }
                else
                {
                    return 0; // Fail
                }
            } else
            {
                return -1; // Not exist
            }  
        }

        #region Admin
        public List<User> getAll() {
            return db.Users.ToList<User>();
        }

        public List<User> getAllAdmin()
        {
            return db.Users.Where(x => x.isAdmin == true).ToList<User>();
        }

        public List<User> getAllCustomer()
        {
            return db.Users.Where(x => x.isAdmin == false).ToList<User>();
        }
        #endregion
    }
}
