namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscriber")]
    public partial class Subscriber
    {
        [Key]
        public int id_subscriber { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
