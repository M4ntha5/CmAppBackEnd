﻿using CmApp.Contracts;
using CmApp.Utils;
using CodeMash.Client;
using CodeMash.Project.Services;
using Isidos.CodeMash.ServiceContracts;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CmApp.Repositories
{
    public class FileRepository : IFileRepository
    {
        private static CodeMashClient Client => new CodeMashClient(Settings.ApiKey, Settings.ProjectId);

        public async Task<Stream> GetFile(string fileId)
        {
            var filesRepo = new CodeMashFilesService(Client);

            var response = await filesRepo.GetFileStreamAsync(new GetFileRequest()
            {
                FileId = fileId,
                ProjectId = Settings.ProjectId
            });
            return response;
        }

        public async Task<string> GetFileUrl(string fileId)
        {
            var filesRepo = new CodeMashFilesService(Client);
            var request = new GetFileRequest { FileId = fileId };
            var response = await filesRepo.GetFileUrlAsync(request);
            return response.Result;
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
            //parsing formated string json
            dynamic data = JObject.Parse(source);
            //accessing json fields
            string fileId = data.id;
            string fileType = data.contentType;

            return Tuple.Create(fileId, fileType);
        }
    }
}
