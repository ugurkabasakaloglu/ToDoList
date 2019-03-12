﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IAUToDoList.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DisplayName("Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
    }
}