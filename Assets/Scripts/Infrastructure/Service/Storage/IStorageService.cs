﻿namespace Infrastructure.Service.Storage
{
    public interface IStorageService
    {
        void Save(string key, object data);

        T Load<T>(string key);
    }
}