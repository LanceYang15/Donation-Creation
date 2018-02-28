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

namespace DonationCreation.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.DonationBox);
            return View(await items.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.DonationBoxId = new SelectList(db.DonationBoxes, "DonationBoxId", "DonationBoxTitle");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,ItemName,ItemQuantity,ItemDescription,DonationBoxId")] Item item, DonationBox donationbox)
        {

            //get the donation box id
            // I don't think the DonationBoxId is being specified
            //var donationBoxId = donationbox.DonationBoxId;
            //item.DonationBoxId = donationBoxId;

            //new code
            //first obtain the user's id
            //var userId = User.Identity.GetUserId();
            //get the profile id that corresponds to the user id thats logged in
            // however the user is able to have many donation boxes, thus many ids but with only one user id
            //var userProfile = db.DonationBoxes.Where(d => d.ApplicationUserId == userId);

            //The solution to this table is by setting Item Table PK to both PK and FK with the Donation
            // Box Table being the PK and FK


            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DonationBoxId = new SelectList(db.DonationBoxes, "DonationBoxId", "DonationBoxTitle", item.DonationBoxId);
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonationBoxId = new SelectList(db.DonationBoxes, "DonationBoxId", "DonationBoxTitle", item.DonationBoxId);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ItemId,ItemName,ItemQuantity,ItemDescription,DonationBoxId")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DonationBoxId = new SelectList(db.DonationBoxes, "DonationBoxId", "DonationBoxTitle", item.DonationBoxId);
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
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
