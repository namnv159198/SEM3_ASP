using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Sem3_UWP.Pages;

namespace Sem3_UWP.Services
{
   public class TokenSaveFileService
   {
       public string result = "";
       private string FileImageUrl = "ImageFile.txt";
        public  async void SaveTokenToFile(string nameFile, string token)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenFile = await storageFolder.CreateFileAsync(nameFile,
                Windows.Storage.CreationCollisionOption.ReplaceExisting); 
            await FileIO.WriteTextAsync(TokenFile, token);
        }

       public async void CreateTokenFile()
       {
           var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
           var TokenFile = await storageFolder.CreateFileAsync(Login.TokenFile,
               Windows.Storage.CreationCollisionOption.ReplaceExisting);
        }
        public   async Task <String> ReadTokenFormFile (String nameFile)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenFile =
                await storageFolder.CreateFileAsync(nameFile, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(TokenFile);
        }

        public async Task<String> ReadTokenFormFile()
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenSaveAsync =
                await storageFolder.CreateFileAsync(Login.TokenFile, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(TokenSaveAsync);
        }

        public async Task<String> GetToken()
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenSaveAsync =
                await storageFolder.CreateFileAsync(Login.TokenFile, Windows.Storage.CreationCollisionOption.OpenIfExists);
            result = await FileIO.ReadTextAsync(TokenSaveAsync);
            Debug.WriteLine(result);

            if (result == null)
            {
                return null;
            }
            return result;
        }
        public async void SaveCameraFileToFile(string token)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenFile = await storageFolder.CreateFileAsync(FileImageUrl,
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(TokenFile, token);
        }
        public async Task<String> ReadCameraFileFormFile()
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenSaveAsync =
                await storageFolder.CreateFileAsync(FileImageUrl, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(TokenSaveAsync);
        }



    }
}
