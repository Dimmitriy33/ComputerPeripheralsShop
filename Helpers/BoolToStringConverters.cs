namespace ComputerPeripheralsShop.Helpers
{
    public static class BoolToStringConverters
    {
        public static string BoolToStringView(bool value)
        {
            if (value)
                return "Yes";
            else
                return "No";
        }
    }
}
