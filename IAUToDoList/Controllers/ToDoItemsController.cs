using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IAUToDoList.Models;
using System.Web.UI.WebControls;
using System.IO;

namespace IAUToDoList.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDoItems
        public async Task<ActionResult> Index()
        {
            var toDoItems = db.ToDoItems.Include(t => t.Category).Include(t => t.Customer).Include(t => t.Department).Include(t => t.Manager).Include(t => t.Organizator).Include(t => t.Side);
            return View(await toDoItems.ToListAsync());
        }

        // GET: ToDoItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // GET: ToDoItems/Create
        public ActionResult Create()
        {
            var todoitem = new ToDoItem();
            todoitem.MeetingDate = DateTime.Now;
            todoitem.FinishDate = DateTime.Now;
            todoitem.PlanedDate = DateTime.Now;
            todoitem.ReviseDate = DateTime.Now;
            todoitem.ScheduledOrganizationDate = DateTime.Now;
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName");
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName");
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name");
            return View(todoitem);
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlanedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MailingSubjects,PosterSubject,PosterCount,Elearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganization,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorparateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                toDoItem.CreateDate = DateTime.Now;
                toDoItem.CreatedBy = User.Identity.Name;
                toDoItem.UpdateDate = DateTime.Now;
                toDoItem.UpdatedBy = User.Identity.Name;
                db.ToDoItems.Add(toDoItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", toDoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", toDoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", toDoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", toDoItem.SideId);
            return View(toDoItem);
        }

        // GET: ToDoItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", toDoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", toDoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", toDoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", toDoItem.SideId);
            return View(toDoItem);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlanedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MailingSubjects,PosterSubject,PosterCount,Elearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganization,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorparateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                toDoItem.UpdateDate = DateTime.Now;
                toDoItem.UpdatedBy = User.Identity.Name;
                db.Entry(toDoItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", toDoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", toDoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", toDoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FirstName", toDoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", toDoItem.SideId);
            return View(toDoItem);
        }

        // GET: ToDoItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            db.ToDoItems.Remove(toDoItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from todo in db.ToDoItems.ToList()
                              select new
                              {
                                  Baslik = todo.Title,
                                  Aciklama = todo.Description,
                                  Kategori = todo.Category.Name,
                                  DosyaEki = todo.Attachment,
                                  Departman = todo.Department.Name,
                                  Taraf = todo.Side.Name,
                                  Musteri = todo.Customer.Name,
                                  Yonetici = todo.Manager.FirstName,
                                  Organizator = todo.Organizator.FirstName,
                                  Durum = todo.Status,
                                  ToplantiTarihi = todo.MeetingDate,
                                  PlanlananTarih = todo.PlanedDate,
                                  BitirilmeTarihi = todo.FinishDate,
                                  RevizeTarihi = todo.ReviseDate,
                                  GorusmeKonusu = todo.ConversationSubject,
                                  DestekleyenFirma = todo.SupporterCompany,
                                  DestekleyenHekim = todo.SupporterDoctor,
                                  GorusmeKatilimciSayisi = todo.ConversationAttendeeCount,
                                  PlanlananOrganizasyonTarihi = todo.ScheduledOrganizationDate,
                                  MailKonulari = todo.MailingSubjects,
                                  AfisKonusu = todo.PosterSubject,
                                  AfisSayisi = todo.PosterCount,
                                  Elearning = todo.Elearning,
                                  YapılanTaramalarınTurleri = todo.TypesOfScans,
                                  YapılanTaramalardakiAsoSayisi = todo.AsoCountInScans,
                                  OrganizasyonTurleri = todo.TypesOfOrganization,
                                  OrganizasyondakiAsoSayisi = todo.AsoCountInOrganization,
                                  AsiOrganizasyonTurleri = todo.TypesOfVaccinationOrganization,
                                  AsiOrganizasyonundakiAsoSayisi = todo.AsoCountInVaccinationOrganization,
                                  AfisicinTazminatMiktari = todo.AmountOfCompansationForPoster,
                                  KurumsalVerimlilikRaporu = todo.CorparateProductivityReport,
                                  OlusturmaTarihi = todo.CreateDate,
                                  OlusturanKullanici = todo.CreatedBy,
                                  GuncellemeTarihi = todo.UpdateDate,
                                  GuncelleyenKullanici = todo.UpdatedBy
                              };
            grid.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=yapilacaklar.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            grid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            Response.ClearContent();
            sw.WriteLine
                ("Baslik,Aciklama,Kategori,DosyaEki,Departman,Taraf,Musteri,Yonetici,Organizator,Durum,ToplantiTarihi,PlanlananTarih,BitirilmeTarihi,RevizeTarihi,GorusmeKonusu,DestekleyenFirma,DestekleyenHekim,GorusmeKatilimciSayisi,PlanlananOrganizasyonTarihi,MailKonulari,AfisKonusu,AfisSayisi,Elearning,YapılanTaramalarınTurleri,YapılanTaramalardakiAsoSayisi,OrganizasyonTurleri,OrganizasyondakiAsoSayisi,AsiOrganizasyonTurleri,AsiOrganizasyonundakiAsoSayisi,AfisicinTazminatMiktari,KurumsalVerimlilikRaporu,OlusturmaTarihi,OlusturanKullanici,GuncellemeTarihi,GuncelleyenKullanici");
            Response.AddHeader("content-dispositon", "attachment;filename=yapilacaklar.csv");
            Response.ContentType = "text/csv";
            var todo = db.ToDoItems.ToList();
            foreach (var tdi in todo)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34}",
                    tdi.Title,
                                  tdi.Description,
                                  tdi.Category.Name,
                                  tdi.Attachment,
                                  tdi.Department.Name,
                                  tdi.Side.Name,
                                  tdi.Customer.Name,
                                  tdi.Manager.FirstName,
                                  tdi.Organizator.FirstName,
                                  tdi.Status,
                                  tdi.MeetingDate,
                                  tdi.PlanedDate,
                                  tdi.FinishDate,
                                  tdi.ReviseDate,
                                  tdi.ConversationSubject,
                                  tdi.SupporterCompany,
                                  tdi.SupporterDoctor,
                                  tdi.ConversationAttendeeCount,
                                  tdi.ScheduledOrganizationDate,
                                  tdi.MailingSubjects,
                                  tdi.PosterSubject,
                                  tdi.PosterCount,
                                  tdi.Elearning,
                                  tdi.TypesOfScans,
                                  tdi.AsoCountInScans,
                                  tdi.TypesOfOrganization,
                                  tdi.AsoCountInOrganization,
                                  tdi.TypesOfVaccinationOrganization,
                                  tdi.AsoCountInVaccinationOrganization,
                                  tdi.AmountOfCompansationForPoster,
                                  tdi.CorparateProductivityReport,
                                  tdi.CreateDate,
                                  tdi.CreatedBy,
                                  tdi.UpdateDate,
                                  tdi.UpdatedBy
                    ));
            }
            Response.Write(sw.ToString());
            Response.End();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
