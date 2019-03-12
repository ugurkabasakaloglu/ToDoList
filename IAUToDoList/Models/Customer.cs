using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IAUToDoList.Models
{
    public class Customer :BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Müşteri Adı")]
        public string Name { get; set; }

        [StringLength(100)]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [StringLength(20)]
        [DisplayName("Faks")]
        public string Fax { get; set; }

        [StringLength(200)]
        [DisplayName("Web Sitesi")]
        public string WebSite { get; set; }

        [StringLength(4000)]
        [DisplayName("Adres")]
        public string Address { get; set; }
        

        [DisplayName("Yapılacaklar")]
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}