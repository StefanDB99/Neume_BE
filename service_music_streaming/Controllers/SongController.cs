using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Logic;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace service_music_streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {

        private readonly ISong _song;

        public SongController(ISong song)
        {
            _song = song;
        }

        [HttpGet("song")]
        public async Task<ISong> GetSongs()
        {
            Console.WriteLine("endpoint TESTTESTTEST");
            ISong song = await _song.GetSong();

            return song;
        }
    }
}

