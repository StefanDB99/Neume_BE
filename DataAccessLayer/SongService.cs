using System;
using Contract_Layer.DTO;
using Contract_Layer.Interfaces.Song;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL
{ 
	public class SongService : ISong_DAL
	{
		public SongService()
		{
			
		}

        public async Task<SongDTO> GetSong()
        {
            MongoClient dbClient = new MongoClient("mongodb://172.19.0.3:27017");

            var database = dbClient.GetDatabase("songs");

            var collection = database.GetCollection<BsonDocument>("songs");

            var filter = Builders<BsonDocument>.Filter.Eq("songID", 1);

            var songDocument = collection.Find(filter).FirstOrDefault().ToList();

           

            SongDTO song = new SongDTO();

            song.songId = songDocument[1].ToString();
            song.songName = songDocument[3].ToString();
            song.songUrl = songDocument[2].ToString();

            return song;

            
            throw new NotImplementedException();
        }
    }
}

