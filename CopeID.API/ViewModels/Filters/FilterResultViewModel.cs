using System;

namespace CopeID.API.ViewModels.Filters
{
    public class FilterResultViewModel
    {
        public Guid? SectionId { get; set; }

        public FilterOptionValueViewModel[] OptionValues { get; set; }
    }
}
