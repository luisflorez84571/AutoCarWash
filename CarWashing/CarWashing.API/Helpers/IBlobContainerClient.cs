﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace CarWashing.API.Helpers
{
    public interface IBlobContainerClient
    {
        Task<BlobClient> GetBlobClientAsync(string name);

        Task CreateIfNotExistsAsync();

        Task SetAccessPolicyAsync(PublicAccessType accessType);
    }
}