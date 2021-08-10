namespace ShorUrl.Models
{
    using System;

    using MongoDB.Bson.Serialization.Attributes;

    public class UrlModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string ShortUrl { get; set; }

        public string FullUrl { get; set; }
    }
}
