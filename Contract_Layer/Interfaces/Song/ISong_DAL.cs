using System;
using Contract_Layer.DTO;

namespace Contract_Layer.Interfaces.Song
{
	public interface ISong_DAL
	{
		public Task<SongDTO> GetSong();
	}
}

