namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public User(String username, String password, String email, String name, String phone, String address, Member member, int point, bool admin, bool status)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.Member = member;
            this.point = point;
            this.admin = admin;
            this.status = status;

        }

        [Key]
        public int id_user { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        public int? id_member { get; set; }

        public int? point { get; set; }

        public bool? admin { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Member Member { get; set; }
    }
}
