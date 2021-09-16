using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using musicApp.Data;
using musicApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicApp.Controllers
{
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Songs.ToListAsync());
            //return StatusCode(StatusCodes.Status200OK);
        }

        //public IEnumerable<Song> Get()
        //{
        //    return _dbContext.Songs;
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found");
            }
            else
            {
                return Ok(song);
            }
        }


        //public Song Get(int id)
        //{
        //    return _dbContext.Songs.Find(id);
        //}

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        //public void Post([FromBody] Song song)
        //{
        //    _dbContext.Songs.Add(song);
        //    _dbContext.SaveChanges();
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found");
            }
            else
            {
                song.Title = songObj.Title;
                song.Language = songObj.Language;
                await _dbContext.SaveChangesAsync();
                return Ok("Record updated successfully");
            }

        }




        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found");
            }
            else
            {
                _dbContext.Songs.Remove(song);
                await _dbContext.SaveChangesAsync();
                return Ok("Record successfully deleted");

            }

        }



    }
}


//namespace Hello_ASP
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SongsController : ControllerBase
//    {

//        private static List<Song> songs = new List<Song>()
//        {
//            new Song(){Id = 0, Title = "Willow", Language = "English"},
//            new Song(){Id = 1, Title = "After", Language = "English"},

//        };

//        [HttpGet]
//        public IEnumerable<Song> Get()
//        {
//            return songs;
//        }

//        [HttpPost]
//        public void Post([FromBody] Song song)
//        {
//            songs.Add(song);
//        }

//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] Song song)
//        {
//            songs[id] = song;
//        }

//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            songs.RemoveAt(id);
//        }

//    }
//}