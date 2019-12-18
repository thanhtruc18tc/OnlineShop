namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {

        public OrderDetail(int idOrder, int idProd, int idSize, int quantity, int price)
        {
            this.id_order = idOrder;
            this.id_product = idProd;
            this.quantity = quantity;
            this.price = price;
            this.id_size = idSize;
        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_order { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_product { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public int id_size { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
