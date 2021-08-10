namespace ShorUrl.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IDbService
    {
        Task InsertRecordAsync<T>(string table, T record);

        Task<List<T>> GetRecordsAsync<T>(string table, Expression<Func<T, bool>> filter = null);
    }
}
