using System.Collections.Generic;
using System.Threading.Tasks;

namespace foodsharing.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddPostAsync(T post);
        Task<T> GetPostAsync(string id);
        Task<IEnumerable<T>> GetPostsAsync(bool forceRefresh = false);
    }
}

