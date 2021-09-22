using System;

namespace CopeID.API.ViewModels.Filters
{
    public class FilterResultRequestViewModel
    {
        public Guid? FilterId { get; set; }

        public FilterResultViewModel[] Results { get; set; }
    }
}
