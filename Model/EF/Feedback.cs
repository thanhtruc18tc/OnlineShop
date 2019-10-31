namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int id_feedback { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string subject { get; set; }

        [Column("feedback", TypeName = "text")]
        public string feedback1 { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }
    }
}
