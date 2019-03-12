using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAUToDoList.Models
{
    public class ToDoItem : BaseEntity
    {
        [StringLength(100)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [StringLength(200)]
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }

        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [DisplayName("Kategori")]
        public virtual Category Category { get; set; }


        [StringLength(200)]
        [DisplayName("Dosya Eki")]
        public string Attachment { get; set; }

        [DisplayName("Departman")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [DisplayName("Departman")]
        public virtual Department Department { get; set; }

        [DisplayName("Taraf")]
        public int? SideId { get; set; }
        [ForeignKey("SideId")]
        [DisplayName("Taraf")]
        public virtual Side Side { get; set; }

        [DisplayName("Müşteri")]
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [DisplayName("Müşteri")]
        public virtual Customer Customer { get; set; }

        [DisplayName("Yönetici")]
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        [DisplayName("Yönetici")]
        public virtual Contact Manager { get; set; }

        [DisplayName("Organizatör")]
        public int? OrganizatorId { get; set; }
        [ForeignKey("OrganizatorId")]
        [DisplayName("Organizatör")]
        public virtual Contact Organizator { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Toplantı Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime MeetingDate { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Planlanan Tarih")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime PlanedDate { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Bitiş Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime FinishDate { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Revize Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime ReviseDate { get; set; }

        [DisplayName("Tartışma Konusu")]
        public string ConversationSubject { get; set; }

        [DisplayName("Destekleyen Firma")]
        public string SupporterCompany { get; set; }

        [DisplayName("Destekleyen Doktor")]
        public string SupporterDoctor { get; set; }

        [DisplayName("Toplantı katılımcı sayısı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int ConversationAttendeeCount { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Planlanan Organizasyon Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime ScheduledOrganizationDate { get; set; }

        [DisplayName("Posta Konuları")]
        public string MailingSubjects { get; set; }

        [DisplayName("Afiş Konusu")]
        public string PosterSubject { get; set; }

        [DisplayName("Afiş Sayısı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int PosterCount { get; set; }

        [DisplayName("E-Learning")]
        public string Elearning { get; set; }

        [DisplayName("Tarama Türleri")]
        public string TypesOfScans { get; set; }

        [DisplayName("Taramalardaki ASO sayısı")]
        public string AsoCountInScans { get; set; }

        [DisplayName("Organizasyon Türleri")]
        public string TypesOfOrganization { get; set; }

        [DisplayName("Organizasyondaki ASO sayısı")]
        public string AsoCountInOrganization { get; set; }

        [DisplayName("Aşı Organizasyonu Türleri")]
        public string TypesOfVaccinationOrganization { get; set; }

        [DisplayName("Aşı Organizasyonundaki ASO sayısı")]
        public string AsoCountInVaccinationOrganization { get; set; }

        [DisplayName("Afiş için Tazminat Miktarı")]
        public string AmountOfCompansationForPoster { get; set; }

        [DisplayName("Kurumsal Verimlilik Raporu")]
        public string CorparateProductivityReport { get; set; }
    }
}