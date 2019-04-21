using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lab4.DAL;
using lab4.Models;
using lab4.Models.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab4.Controllers
{
    public class BooksController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Books
        public IQueryable<BookDTO> GetBooks()
        {
            var books = from b in db.Books
                        select new BookDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Description = b.Description
                        };

            return books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDetailDTO))]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books.Find(id);
            var dto = new BookDetailDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Created = book.Created,
                CreatedBY = book.ApplicationUser
            };
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // PUT: api/Books/5
        public void PutBook(int id, JObject input)
        {
            var jsonInput = JsonConvert.SerializeObject(input);
            BookDTO dto = JsonConvert.DeserializeObject<BookDTO>(jsonInput);

            var oldBook = db.Books.Find(id);
            oldBook.Description = dto.Description;
            oldBook.UpdatedTime = DateTime.Now;
            db.Entry(oldBook).State = EntityState.Modified;
            db.SaveChanges();
        }

        // POST: api/Books
        
        public void PostBook(JObject input)
        {
            var inputStringBook = JsonConvert.SerializeObject(input);
            BookDTO dto = JsonConvert.DeserializeObject<BookDTO>(inputStringBook);
            var newBook = new Book()
            {
                Title = dto.Title,
                Description = dto.Description,
                UpdatedTime = DateTime.Now
            };

            db.Books.Add(newBook);
            db.SaveChanges();
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}