using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SNS.Models;

namespace SNS.Services
{
    public interface IDataStore<T>
    {
        Task<User> PostAsync_login(User usr);

        /*Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);*/
    }
}
