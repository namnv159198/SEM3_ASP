using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sem3_UWP.Models;

namespace Sem3_UWP.Services
{
    public class CreatSongService
    {
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
        private string CREAT_SONG_URL_API = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        private string CONTENT_TYPE = "application/json";

        public async Task<Song> PostSong(Song song)
        {
            var songJson = JsonConvert.SerializeObject(song);

            HttpContent songContent = new StringContent(songJson,Encoding.UTF8,CONTENT_TYPE);

            HttpClient httpClient = new HttpClient();
            string token = await _tokenSaveFileService.ReadTokenFormFile();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var reponse = await httpClient.PostAsync(CREAT_SONG_URL_API, songContent);

            var songContentReturn = await  reponse.Content.ReadAsStringAsync();

            
             var responContent =    JsonConvert.DeserializeObject<Song>(songContentReturn);

             Debug.WriteLine(responContent.name);

            return responContent;
        }
    }
}
