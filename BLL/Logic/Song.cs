using System;
using Contract_Layer.Interfaces.Song;
using Contract_Layer.DTO;
namespace BLL.Logic
{
	public class Song : ISong
	{
        private readonly ISong_DAL _songService;

        public string songUrl { get; private set; }

        public string title { get; private set; }

        public string songId { get; private set; }
        

        public Song(ISong_DAL songService)
		{
            _songService = songService;
		}

        public Song(SongDTO songDto)
        {
            songUrl = songDto.songUrl;
            title = songDto.songName;
            songId = songDto.songId;
        }

        

        public async Task<ISong> GetSong()
        {
            SongDTO songDto = await _songService.GetSong();

            ISong song = new Song(songDto);

            return song;
            throw new NotImplementedException();
        }
    }
}

