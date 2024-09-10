namespace RokhMAUI.Framework.Extensions
{
	public static class DatetimeExtensions
	{
		public static string ToEtraabDateTimeString(this DateTime dateTime)
		{
			return dateTime.ToString("MM-dd-yyyy h:mm:ss");
		}

		public static string ToEtraabShortDateString(this DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd");
		}

		public static string ToEtraabShortDirectoryName(this DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd");
		}

		public static bool IsValid(this DateTime dateTime)
		{
			return dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue;
		}

		public static bool IsValid(this DateTime? dateTime)
		{
			return dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue;
		}

		public static bool IsBetween(this DateTime dateTime, DateTime from, DateTime to)
		{
			return dateTime >= from && dateTime <= to;
		}
	}
}
