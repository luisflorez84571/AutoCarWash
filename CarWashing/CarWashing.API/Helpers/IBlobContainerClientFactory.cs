﻿namespace CarWashing.API.Helpers
{
    public interface IBlobContainerClientFactory
    {
        IBlobContainerClient CreateBlobContainerClient(string connectionString, string containerName);
    }
}