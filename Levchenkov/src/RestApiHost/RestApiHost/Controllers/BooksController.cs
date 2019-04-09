using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RestApiHost.Controllers
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
    }

    public class Database
    {
        public static List<Book> Books = new List<Book>();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Database.Books;
        }

        // GET api/books/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            var book = Database.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            var existingBook = Database.Books.FirstOrDefault(x => x.Id == book.Id);

            if (existingBook != null)
            {
                return BadRequest();
            }

            Database.Books.Add(book);

            return CreatedAtRoute("Get", new { id = book.Id}, book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            var existingBook = Database.Books.FirstOrDefault(x => x.Id == id);

            if (existingBook == null)
            {
                Database.Books.Add(book);
                return CreatedAtRoute("Get", new { id = book.Id }, book);
            }

            existingBook.Id = book.Id;
            existingBook.Author = book.Author;
            existingBook.Created = book.Created;
            existingBook.Description = book.Description;
            existingBook.Title = book.Title;

            //return NoContent(); // if we don't want return books
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = Database.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            Database.Books.Remove(book);
            return NoContent();
        }
    }
}
