namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_order { get; set; }

        [StringLength(50)]
        public string shipName { get; set; }

        [StringLength(10)]
        public string shipMobile { get; set; }

        [StringLength(100)]
        public string shipAddress { get; set; }

        [StringLength(50)]
        public string shipEmail { get; set; }

        public int? id_customer { get; set; }

        public int totalPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        public bool isPaid { get; set; }

        public DateTime createDate { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
