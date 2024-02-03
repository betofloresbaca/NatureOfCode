namespace PSharp
{
    public static class DateTime
    {
        public static int Millis() => System.DateTime.Now.Millisecond;

        public static int Second() => System.DateTime.Now.Second;

        public static int Minute() => System.DateTime.Now.Minute;

        public static int Hour() => System.DateTime.Now.Hour;

        public static int Day() => System.DateTime.Now.Day;

        public static int Month() => System.DateTime.Now.Month;

        public static int Year() => System.DateTime.Now.Year;
    }
}
