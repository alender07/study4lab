using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using study4lab.Models;


namespace study4lab.Controllers
{
    public class RegsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Regs
        public ActionResult Index()
        {
            return View(db.Regs.ToList());
        }

        // GET: Regs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // GET: Regs/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Auth()
        {
            ViewBag.Message = "Вход";
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        // POST: Regs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Auth(RegLogin model)
        {
            if (ModelState.IsValid)
            {
                Reg reg = null;
                using (RegContext db = new RegContext())
                {
                    reg = db.Regs.FirstOrDefault(u => u.email == model.email && u.Password == model.Password);

                }
                if (reg != null)
                {
                    FormsAuthentication.SetAuthCookie(model.email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким e-mail и паролем нет");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,email,Phone,Password,PasswordConfirm")] Reg reg)
        {
            if (ModelState.IsValid)
            {
                db.Regs.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Auth", "Regs");
            }

            return View(reg);
        }

        // GET: Regs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // POST: Regs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,email,Phone,Password,PasswordConfirm")] Reg reg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }

        // GET: Regs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // POST: Regs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reg reg = db.Regs.Find(id);
            db.Regs.Remove(reg);
            db.SaveChanges();
            return RedirectToAction("Index");
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
