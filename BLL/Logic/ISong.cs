using System;
namespace BLL.Logic
{
	public interface ISong
	{
        public string songUrl { get; }
        public string songId { get; }
        public string title { get; }

        public Task<ISong> GetSong();
    }
}

