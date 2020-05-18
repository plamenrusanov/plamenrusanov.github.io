namespace Tapas.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Tapas";

        public const string AdministratorName = "Administrator";

        public const string OperatorName = "Operator";

        public const string UserNameAsString = "User";

        public const string EmailAdministrator = "plamen.rusanov@abv.bg";

        public const string EmailOperator = "operator@tapas.bg";

        public const string AreaAdmin = "Administration";

        public const string DefaultProductImage = "utvaxhqgzon5lczgkoak.jpg";

        public const string LoginPageRoute = "/Identity/Account/Login";

        public const string IndexRoute = "/";

        public const string RefererHeader = "Referer";

        public const decimal DeliveryFee = 2.00m;

        public const decimal OrderPriceMin = 10m;

        // Max order price to charge delivery fee
        public const decimal MOPTCDF = 15m;

        public const decimal OrderPriceForBonus = 25m;
    }
}
