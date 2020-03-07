using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sem3_UWP.Models;
using Sem3_UWP.Pages;

namespace Sem3_UWP.Services
{
    class GetListSongService
    {
        private string GET_LIST_SONG_URL_API = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();


        public ObservableCollection<Song> LoadSongs()
        {

            Task<ObservableCollection<Song>> list = Task.Run(async () => await LoadSong());
            return list.Result;
        }
       

        public async Task<ObservableCollection<Song>> LoadSong()
        {
            Debug.WriteLine("dang run");
            string token = await _tokenSaveFileService.ReadTokenFormFile();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            // gửi đến đây (link), món quà này (contentToSend), chờ quá trình gửi thành công, thì lấy xác nhận từ người nhận.
            var response = await httpClient.GetAsync(GET_LIST_SONG_URL_API);
            // đọc dữ liệu response từ người nhận.

            var stringContent = await response.Content.ReadAsStringAsync();
            JArray o = JArray.Parse(stringContent);
            Debug.WriteLine(o);
            ObservableCollection<Song> data = o.ToObject<ObservableCollection<Song>>();
            Debug.WriteLine(data[0].author);
            Debug.WriteLine(data[1].author);
            Debug.WriteLine(data[2].author);

            return data;
        }


        
    }
}
