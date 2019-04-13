using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Htp.BooksAPI.Infrastructure;
using System.Security.Claims;

namespace Htp.BooksAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<BookViewModel>> GetBooks()
        {
            var books = bookService.GetAll();

            return Ok(books);
        }

        // GET api/books/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<BookViewModel>> GetBook(int id)
        {
            var book = await bookService.GetAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<BookViewModel>> PostBook([FromBody] BookViewModel bookViewModel)
        {
            //bookViewModel.CreatedByUserID = User.GetUserId();

            bookViewModel = await bookService.AddAsync(bookViewModel);

            return CreatedAtAction(nameof(GetBook), new { id = bookViewModel.Id }, bookViewModel);
        }

        /// <summary>
        /// Puts the book. // PUT: api/books/5
        /// </summary>
        /// <returns>The book.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="bookViewModel">Book view model.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutBook(int id, BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id)
            {
                return BadRequest();
            }

            //bookViewModel.UpdatedByUserID = User.GetUserId();

            await bookService.EditAsync(bookViewModel);

            return NoContent();
        }

        /// <summary>
        /// Deletes the book. DELETE: api/books/5
        /// </summary>
        /// <param name="id">Book identifier to delete.</param>
        /// <response code="204">Successful operation</response>
        /// <response code="404">Book not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await bookService.GetAsync(id);

            if (book == null)
                return NotFound();

            await bookService.DeleteAsync(id);

            return NoContent();
        }
    }
}