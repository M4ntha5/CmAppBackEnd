﻿using CmApp.Contracts.Interfaces.Repositories;
using CmApp.Contracts.Models;
using CmApp.Utils;
using image4ioDotNetSDK;
using image4ioDotNetSDK.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CmApp.BusinessLogic.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly Image4ioAPI _imagesClient = new Image4ioAPI(Settings.Image4IoApiKey, Settings.Image4IoSecret);
        private readonly Context _context;

        public FileRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// bring back if needed, it saves downloaded tracking images
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
     /* public async Task<List<string>> InsertTrackingImages(string carId, List<UploadImageRequest.File> files)
        {
            if(files == null || files.Count == 0)
                throw new BusinessException("Cannot add images, because no image provided");

            var response = await ImagesClient.UploadImageAsync(
                new UploadImageRequest()
                {
                    Path = "/tracking/" + carId,
                    UseFilename = true,
                    Overwrite = false,
                    Files = files
                });

            var urls = response.UploadedFiles.Select(x =>x.Url).ToList();
            return urls;
        }*/

        public IEnumerable<string> ListFolder(string folder)
        {
            var response = _imagesClient.ListFolder(
                new ListFolderRequest()
                {
                    Path = folder
                });

            var urls = response.Images.Select(x => x.Url);
            return urls;
        }

        public async Task<bool> DeleteImage(string pathToImage)
        {
            var response = await _imagesClient.DeleteImageAsync(
                new DeleteImageRequest()
                {
                    Name = pathToImage,
                });
            return response.Success;
        }

        public async Task<bool> DeleteFolder(string folder)
        {
            var response = await _imagesClient.DeleteFolderAsync(
                new DeleteFolderRequest()
                {
                    Path = folder,
                });
            return response.Success;
        }

        public byte[] StreamToByteArray(MemoryStream mem)
        {
            mem.Seek(0, SeekOrigin.Begin);
            int count = 0;
            byte[] byteArray = new byte[mem.Length];
            while (count < mem.Length)
            {
                byteArray[count++] = Convert.ToByte(mem.ReadByte());
            }
            return byteArray;
        }
        public byte[] Base64ToByteArray(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public string ByteArrayToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        public Tuple<string, string> GetFileId(object file)
        {
            //all file names list
            var names = file;
            // converting one of the file to string
            var source = names.ToString();
            //parsing formatted string json
            dynamic data = JObject.Parse(source);
            //accessing json fields
            string fileId = data.id;
            string fileType = data.contentType;

            return Tuple.Create(fileId, fileType);
        }

        public Task<string> GetFileUrl(string fileId)
        {
            throw new NotImplementedException();
        }
        public Task<Stream> GetFile(string fileId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> InsertCarImages(int carId, List<UploadImageRequest.File> files)
        {
            throw new NotImplementedException();
        }
    }
}
