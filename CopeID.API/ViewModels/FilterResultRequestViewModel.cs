using System;

namespace CopeID.API.ViewModels
{
    public class FilterResultRequestViewModel
    {
        public Guid? FilterId { get; set; }

        public FilterResultViewModel[] Results { get; set; }
    }
}
