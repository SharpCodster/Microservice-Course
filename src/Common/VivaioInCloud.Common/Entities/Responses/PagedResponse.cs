namespace VivaioInCloud.Common.Entities.Responses
{
    public class PagedResponse<T> : BaseResponse
        where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public PaginationMetadata Metadata { get; set; }

        public PagedResponse()
        {
            Metadata = new PaginationMetadata();
        }

        public PagedResponse(int? skip, int? take, int totalCount)
        {
            int pageSize = totalCount;
            int skipped = 0;

            if (take != null)
            {
                pageSize = (int)take;
            }

            if (skip != null)
            {
                skipped = (int)skip;
            }

            Metadata = new PaginationMetadata()
            {
                TotalPages = totalCount,
                Page = (int)Math.Ceiling((double)skipped / (double)pageSize) + 1,
                PageSize = pageSize,
            };
        }

    }

    public class PaginationMetadata
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
        public int TotalPages { get; set; } = 0;
    }
}

