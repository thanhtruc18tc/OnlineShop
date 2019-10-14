namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SizeColor")]
    public partial class SizeColor
    {
        [Key]
        public int id_size_color { get; set; }

        [StringLength(1)]
        public string size { get; set; }

        [StringLength(20)]
        public string color { get; set; }

        public int? quantity { get; set; }

        public int id_product { get; set; }

        public virtual Product Product { get; set; }
    }
}
