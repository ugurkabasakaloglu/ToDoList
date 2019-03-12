using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IAUToDoList.Models
{
    public class Contact :BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        [DisplayName("Ad")]
        public string FirstName { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [StringLength(100)]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Yapılacaklar")]
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }

    }
}