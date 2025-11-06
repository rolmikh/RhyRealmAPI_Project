using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace RhyRealmAPI_Project.Service
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SaveVerificationCodeToCache(string email, int? code)
        {
            if (code == null)
            {
                return;
            }

            _memoryCache.Set(email, code, TimeSpan.FromMinutes(10));
        }

        public string? GetCode(string email)
        {
            var savedCode = _memoryCache.Get(email);
            return savedCode.ToString();
        }

        public void RemoveCode(string email)
        {
            _memoryCache.Remove(email);
        }

    }
}
