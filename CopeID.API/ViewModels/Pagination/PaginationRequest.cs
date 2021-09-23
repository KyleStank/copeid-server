using System;

namespace CopeID.API.ViewModels.Pagination
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public PaginationRequest()
        {
            PageNumber = -1;
            PageSize = -1;
        }

        public PaginationRequest(int pageNumber, int pageSize)
        {
            PageNumber = Math.Max(1, pageNumber);
            PageSize = pageSize;
        }

        public bool IsValid() => PageNumber > 0 && PageSize > 0;
    }
}
