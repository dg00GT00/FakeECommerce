namespace Core.Enums
{
    public enum SortBy
    {
        /*
         * The NameAsc should be the first value of the first value
         * of the SortBy enum in case a value not be specified in
         * url query parameter
         */
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}