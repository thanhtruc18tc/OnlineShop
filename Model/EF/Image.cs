namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int id_image { get; set; }

        [Column(TypeName = "ntext")]
        public string link { get; set; }

        public int? id_product { get; set; }

        public virtual Product Product { get; set; }
    }
}
