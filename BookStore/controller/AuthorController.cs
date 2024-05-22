

using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.controller
{
    public class AuthorController : Controller
    {
        public IBaseRepoBookAuthor<AuthorModel> AuthorRepo { get; }

        public AuthorController(IBaseRepoBookAuthor<AuthorModel> AuthorRepo)
        {
            this.AuthorRepo = AuthorRepo;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var auth = AuthorRepo.List();
            return View(auth);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var auth = AuthorRepo.Find(id);
            return View(auth);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorModel author)
        {
            try
            {
                AuthorRepo.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = AuthorRepo.Find(id);
            return View(auth);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorModel author)
        {
            try
            {
                AuthorRepo.Update(id,author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var auth = AuthorRepo.Find(id);

            return View(auth);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,AuthorModel auth)
        {
            try
            {
                AuthorRepo.Delete(id);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public interface IBaseRepoBookAuthor
    {
    }
}
