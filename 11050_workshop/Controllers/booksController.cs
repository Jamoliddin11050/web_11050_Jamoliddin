using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _11050_workshop.Data;
using _11050_workshop.Models;
using _11050_workshop.Repositories;

namespace _11050_workshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly BookShopDbContext _context;
        private readonly IPublishersRepository _booksRepository;

        public booksController(IPublishersRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IEnumerable<book>> Getbooks()
        {
          
            return await _booksRepository.GetAllBooks();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<book>> Getbook(int id)
        {
            var  book= await _booksRepository.GetSingleBook(id);
          if (book == null)
          {
              return NotFound();
          }
            
            return Ok(book);
        }

        // PUT: api/books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbook(int id, book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            

           await _booksRepository.UpdateBook(book);

            return NoContent();
        }

        // POST: api/books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<book>> Postbook(book book)
        {
          
            _booksRepository.CreateBook(book);
            return CreatedAtAction("Getbook", new { id = book.Id }, book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebook(int id)
        {
           _booksRepository.DeleteBook(id);

            return NoContent();
        }

       
    }
}
