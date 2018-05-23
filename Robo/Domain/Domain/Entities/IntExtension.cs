namespace Domain
{
    public static class IntExtension
    {
        public static bool IsProgressiveFor(this int number, int value)
        {
            return number + 1 == value || number - 1 == value;
        }
    }
}
