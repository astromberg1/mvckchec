using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System;

namespace MVCkunskapscheck.Controllers
    {
    public class PersonController : Controller
        {
        public static List<MVCkunskapscheck.Models.Person> list = new List<MVCkunskapscheck.Models.Person>();
        public static bool start = false;
        public static MVCkunskapscheck.Models.Person CurrPerson = new MVCkunskapscheck.Models.Person();
        public PersonController()
            {
            if (!start)
                {
                list.Add(new Models.Person { namn = "Sven", skapad=DateTime.Now, Telefon= "07345345" });
                list.Add(new Models.Person { namn = "pelle", skapad = DateTime.Now, Telefon = "073123445" });
                list.Add(new Models.Person { namn = "Sune", skapad = DateTime.Now, Telefon = "073424435" });
                start = true;
                }
            }

        // GET: Person
        public ActionResult Index()
            { // Instantiate a new view model





            return View(list);
            }
        //    [HttpPost]
        public ActionResult DeleteDirekt(string id)
            { // Instantiate a new view model

                {
                Models.Person product = list.Find(p => p.namn == id);
                list.Remove(product);
                return RedirectToAction("Index");
                }





            }


        public ActionResult Create()
            {
            var person = new Models.Person();



            return View(person);
            }


        [HttpPost]
        public ActionResult Create(Models.Person person)
            {


            if (ModelState.IsValid)
                {
                list.Add(person);
                return RedirectToAction("Index");
                }

            return View(person);



            }

        public ActionResult Delete(string id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
            Models.Person product = list.Find(p => p.namn == id);
            if (product == null)
                {
                return HttpNotFound();
                }
            return View(product);
            }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
            {
            Models.Person product = list.Find(p => p.namn == id);
            list.Remove(product);
            return RedirectToAction("Index");
            }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
            Models.Person product = list.Find(p => p.namn == id);
            CurrPerson = product;
            if (product == null)
                {
                return HttpNotFound();
                }




            return View(product);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "namn")] Models.Person product)
            {
            if (ModelState.IsValid)
                {
                list.Find(p => p.namn == CurrPerson.namn).namn = product.namn;

                return RedirectToAction("Index");
                }

            return View(product);
            }

        public ActionResult Details(string id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Models.Person product = list.Find(p => p.namn == id);
            if (product == null)
                {
                return HttpNotFound();
                }
            return View(product);

            }
       }
    }

