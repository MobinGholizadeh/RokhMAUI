using RokhMAUI.Framework.Extensions;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace RokhMAUI.Framework.Extensions
{
	public static class StringExtension
	{
		public static string ToJson<T>(this T obj, bool upper = false)
		{
			return JsonSerializer.Serialize(obj, GetJsonOptions(upper));
		}

		public static string ToJson<T>(this List<T> list, bool upper = false)
		{
			return JsonSerializer.Serialize(list, GetJsonOptions(upper));
		}

		public static string ToPrettyJson(this object obj, bool upper = false)
		{
			var options = GetJsonOptions(upper);
			options.WriteIndented = true;
			return JsonSerializer.Serialize(obj, options);
		}

		public static T FromJson<T>(this string str, bool upper = false)
		{
			return JsonSerializer.Deserialize<T>(str, GetJsonOptions(upper));
		}

		public static string ToBrokerJson<T>(this T obj)
		{
			return JsonSerializer.Serialize(obj, GetJsonOptions(false));
		}

		public static T FromBrokerJson<T>(this string str)
		{
			return JsonSerializer.Deserialize<T>(str, GetJsonOptions(false));
		}

		private static JsonSerializerOptions GetJsonOptions(bool upper)
		{
			var options = new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			};

			options.Converters.Add(new JsonStringEnumConverter());

			if (!upper) options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

			return options;
		}

		public static byte[] ToUtfBytes(this string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}

		public static T FromXml<T>(this string input) where T : class
		{
			XmlSerializer ser = new XmlSerializer(typeof(T));
			using (StringReader sr = new StringReader(input))
			{
				return (T)ser.Deserialize(sr);
			}
		}

		public static Guid ToGuid(this string id)
		{
			Guid.TryParse(id, out Guid result);
			return result;
		}

		public static string ToXml<T>(this T value)
		{
			var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			var serializer = new XmlSerializer(value.GetType());
			var settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.OmitXmlDeclaration = true;

			using (var stream = new StringWriter())
			using (var writer = XmlWriter.Create(stream, settings))
			{
				serializer.Serialize(writer, value, emptyNamespaces);
				return stream.ToString();
			}
		}

		public static bool HasNonAsciiChars(this string str)
		{
			const int MaxAnsiCode = 255;
			return str.Any(c => c > MaxAnsiCode);
		}

		public static string CapitalizeFirstLetter(this string input)
		{
			return input switch
			{
				null or "" => input,
				_ => input[0].ToString().ToUpper() + input.Substring(1),
			};
		}

		public static string ToLowerFirstLetter(this string input)
		{
			return input switch
			{
				null or "" => input,
				_ => input[0].ToString().ToLower() + input.Substring(1),
			};
		}

		public static List<string> ToList(this string input, char seperator = ',')
		{
			if (string.IsNullOrWhiteSpace(input)) return new List<string>(0);
			return input.Split(seperator).ToList();
		}

		public static int UniqueCharsCount(this string input)
		{
			var chars = input.ToArray();
			var uniqueChars = chars.Distinct();
			var count = uniqueChars.Where(x => chars.Where(c => c == x).Count() == 1).Count();
			return count;
		}

		public static SecureString ToSecureString(this string input)
		{
			var s = new SecureString();
			foreach (var c in input)
				s.AppendChar(c);
			return s;
		}

		public static string FromSecureString(this SecureString input)
		{
			nint valuePtr = nint.Zero;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(input);
				return Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}
		}

	}
}
