using System.Collections.Generic;

namespace CopeID.API.ViewModels.Pagination
{
    public class PaginationResponse<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }

        public PaginationResponse(int count, IEnumerable<T> data)
        {
            Count = count;
            Data = data;
        }
    }
}
