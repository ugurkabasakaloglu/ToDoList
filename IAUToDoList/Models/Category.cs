using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IAUToDoList.Models
{
    public class Category : BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Kategori Adı Gereklidir.")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [DisplayName("Yapılacaklar")]
        public virtual ICollection<ToDoItem> ToDoItems {get;set;}

    }
}