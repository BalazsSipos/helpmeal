﻿using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Services.BlobService
{
    public interface IBlobStorageService
    {
        CloudBlobContainer GetCloudBlobContainer();
        Task<CloudBlockBlob> MakeBlobFolderAndSaveImageAsync(string id, IFormFile image);
        void DeleteBlobFolder(long id);
    }
}
