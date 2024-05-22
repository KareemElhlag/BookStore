using BookStore.Models;
using BookStore.Models.Repository;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.controller
{
    public class BooksController : Controller
    {
        private readonly IBaseRepoBookAuthor<BookModel> BooksRepo;
        private readonly IBaseRepoBookAuthor<AuthorModel> author;
        private readonly IWebHostEnvironment hosting;
   

        public BooksController(IBaseRepoBookAuthor<BookModel> BooksRepo, IBaseRepoBookAuthor<AuthorModel> author, IWebHostEnvironment hosting)
        {
            this.BooksRepo = BooksRepo;
            this.author = author;
            this.hosting = hosting;
        }
        // GET: BooksController
        public ActionResult Index()
        {
            var books = BooksRepo.List();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            var book = BooksRepo.Find(id);
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorVM
            {
                Authors = InsDufelt()
            };

            return View(model);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorVM model)
        {
            try
            {
                string ImgNameexe = AddAndEditImg(model.FileImg) ?? String.Empty;

                if (model.AuthorId == -1)
                {
                    ViewBag.massage = "Wrong! please Enter Author";
                    return View(GetAuthorvm());
                }
                var auth = author.Find(model.AuthorId);

                BookModel book = new BookModel
                {
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    AuthorId = auth.Id,
                    ImagUrl = ImgNameexe

                };
                BooksRepo.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) { return View(); }


        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BooksRepo.Find(id);

            var NVModel = new BookAuthorVM
            {
                BookId = (int)(book.Id == null ? 0 : book.Id),
                Description = book.Description,
                Title = book.Title,
                Price = book.Price,
                imgurl = book.ImagUrl,
                Authors = author.List().ToList()
            };
            return View(NVModel);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorVM MVModel)
        {

            try
            {
                string? oldFileName = MVModel.imgurl?? string.Empty;
                string ImgNameexe = IsExaist(MVModel.FileImg, oldFileName)?? String.Empty;
               
                var auth = author.Find(MVModel.AuthorId);
                BookModel book = new BookModel



                {
                    Id = MVModel.BookId,
                    Title = MVModel.Title,
                    Description = MVModel.Description,
                    Price = MVModel.Price,
                    Author = auth,
                    ImagUrl = ImgNameexe
                };
                BooksRepo.Update(MVModel.BookId, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BooksRepo.Find(id);
            return View(book);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookModel Rbook)
        {
            try
            {
                BooksRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<AuthorModel> InsDufelt()
        {
            var Authors = author.List().ToList();
            Authors.Insert(0, new AuthorModel { Id = -1, AuthorName = "---please select Author--" });
            return Authors;
        }
        BookAuthorVM GetAuthorvm()
        {
            var vmodel = new BookAuthorVM
            {
                Authors = InsDufelt()
            };
            return vmodel;
        }

        String? AddAndEditImg(IFormFile FileImg)
        {
            if (FileImg != null)
            {
                string imgfilepathsave = Path.Combine(hosting.WebRootPath, "uplood");
                string fullPath = Path.Combine(imgfilepathsave, FileImg.FileName);
                FileImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                return FileImg.FileName;
            }
            return null;

        }
        string IsExaist(IFormFile FileImg, string imgurl)
        {
         
            string imgfilepathsave = Path.Combine(hosting.WebRootPath, "uplood");
            string fullPath = Path.Combine(imgfilepathsave, FileImg.FileName);
            string oldFileName = imgurl;
            if (oldFileName == null)
            {
                FileImg.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                //get the exaist file path from wwwroot
                string? fullOldPath = Path.Combine(imgfilepathsave, oldFileName);
                if (fullOldPath != fullPath)
                {

                    System.IO.File.Delete(fullOldPath);
                    FileImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                return FileImg.FileName;
            }
            return imgurl;
        }
        public ActionResult Search (String Term)
        {
            var result = BooksRepo.Search(Term);
            return View("Index", result);
        }

    }

}
