﻿using BookStore.Models.Repository;
using BookStore.ViewModels;
using library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepositry<Book> bookRepository;
        private readonly IBookStoreRepositry<Author> author;
        private readonly IHostingEnvironment hostingEnvironment;

        public BookController(IBookStoreRepositry<Book> bookRepositry, IBookStoreRepositry<Author> author,IHostingEnvironment hostingEnvironment)
        {
            this.bookRepository = bookRepositry;
            this.author = author;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var books = bookRepository.Find(id);
            return View(books);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = listAuthor(),
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
            {
                    string fileName = string.Empty;
                    if(model.file != null) 
                    {
                        string upload = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                        fileName = model.file.FileName;
                        string fullPath = Path.Combine(upload, fileName);
                        model.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    if (model.AuthorId == -1)
                    {
                        ViewBag.Message = "Please select an author from list";

                        return View(GetAllBookAuthor());
                    }
                    var _Author = author.Find(model.AuthorId);
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        description = model.Description,
                        Author = _Author,
                        ImageUrl=fileName
                    };
                    bookRepository.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllBookAuthor());
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var viewModel = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.description,
                AuthorId = book.Author.Id,
                Authors = listAuthor(),
            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel viewModel)
        {
            try
            {
                var _Author = author.Find(viewModel.AuthorId);
                Book book = new Book
                {
                    Id = viewModel.BookId,
                    Title = viewModel.Title,
                    description = viewModel.Description,
                    Author = _Author,
                };
                bookRepository.Update(book, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book= bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult confirmDelete(int id)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> listAuthor()
        {
            var Authors = author.List().ToList();
            Authors.Insert(0, new Author { Id = -1,Name="Please select an author" });
            return Authors;
        } 

        BookAuthorViewModel GetAllBookAuthor()
        {
            var vmodel = new BookAuthorViewModel
            {
                Authors = listAuthor()
            };
            return vmodel;
        }
    }
}

