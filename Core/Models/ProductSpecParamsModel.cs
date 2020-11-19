using Core.Enums;

namespace Core.Models
{
    public class ProductSpecParamsModel
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public SortBy Sort { get; set; }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}