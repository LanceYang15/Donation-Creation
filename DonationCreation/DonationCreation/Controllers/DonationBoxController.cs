using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DonationCreation.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace DonationCreation.Controllers
{
    public class DonationBoxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Hidden hide = new Hidden();


        // GET: DonationBox
        public async Task<ActionResult> Index()
        {
 
            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName");

            var donationBoxes = db.DonationBoxes.Include(d => d.ApplicationUser).Include(d => d.DonationBoxCategory);
            
            return View(await donationBoxes.ToListAsync());
        }


        //creating drop down box for sort
        [HttpPost]
        public async Task<ActionResult> Index(int DonationBoxCategoryId)
        {
            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName");
            var donationBoxes = db.DonationBoxes.Where(d => d.DonationBoxCategoryId == DonationBoxCategoryId);


            return View(await donationBoxes.ToListAsync());
        }


        // GET: 
        public ActionResult WarningDisplay()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> WarningDisplay([Bind(Include = "GuestUserId, GuestUserEmail, GuestUserFirstName, GuestUserLastName, GuestUserCity, State, GuestUserZipCode")] GuestUser guestUser)
        {

            if (ModelState.IsValid)
            {
                db.GuestUsers.Add(guestUser);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return View(guestUser);
        }


        // GET: DonationBox/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DonationBox donationBoxes = db.DonationBoxes.Include(d => d.ApplicationUser).Include(d => d.DonationBoxCategory).Where(n => n.DonationBoxId == id).First();

            if (donationBoxes == null)
            {
                return HttpNotFound();
            }

            return View(donationBoxes);
        }


        // DonationBox/Details/5
        [HttpPost]
        public async Task<ActionResult> Details(string trackingNumber)
        {

            if (ModelState.IsValid)
            {

                string guestEmail = hide.RetrieveEmail();
                string text2 = trackingNumber;

                MailGun.SendSimpleMessage(guestEmail, text2);

                return RedirectToAction("Index");

            }

            return View();
        }


        // GET: DonationBox/Create
        public ActionResult Create()
        {

            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName");
            return View();
        }

        // POST: DonationBox/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DonationBoxId,DonationBoxTitle,DonationBoxStoryDescription,DonationBoxImage,DonationBoxItemDescription,DonationBoxCreatedDate,ApplicationUserId,DonationBoxCategoryId")] DonationBox donationBox, HttpPostedFileBase file)
        {

            var userId = User.Identity.GetUserId();
            donationBox.ApplicationUserId = userId;
            donationBox.DonationBoxCreatedDate = DateTime.Now;

            //image code
            if (file != null)
            {

                donationBox.DonationBoxImage = userId + Path.GetExtension(file.FileName);

                file.SaveAs(Server.MapPath("//Content//Images//") + donationBox.DonationBoxImage);
            }

            if (ModelState.IsValid)
            {
                db.DonationBoxes.Add(donationBox);
                await db.SaveChangesAsync();


                return RedirectToAction("Index");

            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", donationBox.ApplicationUserId);
            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName", donationBox.DonationBoxCategoryId);


            return View(donationBox);
        }


        // GET: DonationBox/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationBox donationBox = await db.DonationBoxes.FindAsync(id);
            if (donationBox == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", donationBox.ApplicationUserId);
            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName", donationBox.DonationBoxCategoryId);
            return View(donationBox);
        }


        // POST: DonationBox/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DonationBoxId,DonationBoxTitle,DonationBoxStoryDescription,DonationBoxImage,DonationBoxImageToEdit,DonationBoxCreatedDate,ApplicationUserId,DonationBoxCategoryId")] DonationBox donationBox, HttpPostedFileBase file)
        {

            var userId = User.Identity.GetUserId();

            //Image code
            if (file != null)
            {
                donationBox.DonationBoxImageToEdit = userId + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//Images//") + donationBox.DonationBoxImageToEdit);
            }

            if (ModelState.IsValid)
            {             
                db.Entry(donationBox).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", donationBox.ApplicationUserId);
            ViewBag.DonationBoxCategoryId = new SelectList(db.DonationBoxCategories, "DonationBoxCategoryId", "DonationBoxCateogryName", donationBox.DonationBoxCategoryId);

            return View(donationBox);
        }


        // GET: DonationBox/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationBox donationBox = await db.DonationBoxes.FindAsync(id);
            if (donationBox == null)
            {
                return HttpNotFound();
            }
            return View(donationBox);
        }


        // POST: DonationBox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonationBox donationBox = await db.DonationBoxes.FindAsync(id);
            db.DonationBoxes.Remove(donationBox);
            await db.SaveChangesAsync();
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
