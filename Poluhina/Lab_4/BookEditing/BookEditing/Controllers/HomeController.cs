﻿using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookEditing.Controllers
{
    public class HomeController : Controller
    {
        IBookService<BookDTO> bookService;
        public HomeController(IBookService<BookDTO> repository)
        {
            bookService = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var booksDTO = bookService.GetList();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookViewModel>();
            }).CreateMapper();

            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(booksDTO);

            return View(books);
        }

        [HttpPost]
        public ActionResult Add(BookViewModel book)
        {
            book.Created = System.DateTime.Now;
            book.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDTO>()).CreateMapper();
            var bookDTO = mapper.Map<BookViewModel, BookDTO>(book);
            bookService.Add(bookDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookService.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var book = bookService.Get(id);
            if (book == null)
                return HttpNotFound();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookViewModel>();
            }).CreateMapper();
            var bookView = mapper.Map<BookDTO, BookViewModel>(book);
            return View(bookView);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            book.Created = System.DateTime.Now;
            book.UpdatedBy = System.Web.HttpContext.Current.User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDTO>()).CreateMapper();
            var bookDAL = mapper.Map<BookViewModel, BookDTO>(book);
            bookService.Change(bookDAL);
            return RedirectToAction("Index");
        }
    }
}

