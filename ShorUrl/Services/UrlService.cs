using HashidsNet;

using ShorUrl.Interfaces;
using ShorUrl.Models;

using System.Threading.Tasks;
using System.Linq;

namespace ShorUrl.Services
{
    public class UrlService
    {
        private readonly IDbService _mongoDbService;

        public UrlService(IDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<UrlModel> SaveUrl(string fullUrl)
        {
            var shortUrl = GetShorUrl(fullUrl);
            var urlRec = new UrlModel
            {
                FullUrl = fullUrl,
                ShortUrl = shortUrl
            };

            await _mongoDbService.InsertRecordAsync("Url", urlRec);

            return urlRec;
        }

        public async Task<UrlModel> GetUrl(string fullUrl)
        {
            var record = (await _mongoDbService.GetRecordsAsync<UrlModel>("Url", x => x.FullUrl == fullUrl)).FirstOrDefault();

            return record;
        }

        private string GetShorUrl(string fullUrl)
        {
            var hashids = new Hashids(fullUrl);
            var shortUrl = hashids.Encode(1, 2, 3);

            return shortUrl;
        }
    }
}
