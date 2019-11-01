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
        public  User(string username, string password, string email, string name, string phone, string address, int id_type, bool isAdmin, bool isActive) {
            this.username = username;
            this.password = password;
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.id_type = id_type;
            this.isAdmin = isAdmin;
            this.isActive = isActive;
        }

        public User()
        {

        }

        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(32)]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        public bool isAdmin { get; set; }

        public bool isActive { get; set; }

        public int id_type { get; set; }

        public virtual Order Order { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
