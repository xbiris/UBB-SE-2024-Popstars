using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace SE_project
{
	public static class ConfigurationLoaderFactory
	{
		public static IConfigurationLoader GetConfigurationLoader(string path)
		{
			var extension = Path.GetExtension(path).ToLower();
			return extension switch
			{
				".json" => new JsonConfigurationLoader(path),
				".xml" => new XmlConfigurationLoader(path),
				_ => throw new NotSupportedException($"Unsupported file format: {extension}")
			};
		}
	}

	public interface IConfigurationLoader
	{
		T GetValue<T>(string key);
	}

	public class JsonConfigurationLoader : IConfigurationLoader
	{
		private readonly JsonElement jsonElement;

		public JsonConfigurationLoader(string path)
		{
			var jsonText = File.ReadAllText(path);
			using (JsonDocument doc = JsonDocument.Parse(jsonText))
			{
				jsonElement = doc.RootElement.Clone();
			}
		}
		public T GetValue<T>(string key)
		{
			if (jsonElement.TryGetProperty(key, out var value))
			{
				T? returnvalue = JsonSerializer.Deserialize<T>(value.GetRawText());
				if (returnvalue != null)
				{
					return returnvalue;
				}
				else
				{
					throw new NullReferenceException($"Cannot deserialize value for key: {key}");
				}
			}
			else
			{
				throw new KeyNotFoundException($"Key not found: {key}");
			}
		}
	}

	public class XmlConfigurationLoader : IConfigurationLoader
	{
		private readonly XDocument xDocument;

		public XmlConfigurationLoader(string path)
		{
			xDocument = XDocument.Load(path);
		}

		public T GetValue<T>(string key)
		{
			var element = xDocument.Descendants("setting")
								   .FirstOrDefault(e => e.Attribute("name")?.Value == key);

			if (element == null)
			{
				throw new KeyNotFoundException($"Key not found: {key}");
			}
			var type = element.Attribute("type")?.Value;
			var value = element.Value;

			if (type == "string" || type == "number" || type == "bool")
			{
				return (T)Convert.ChangeType(value, typeof(T));
			}
			else if (type == "list")
			{
				return (T)Convert.ChangeType(element.Elements("item").Select(x => x.Value).ToList(), typeof(T));
			}

			throw new NotSupportedException($"Unsupported type: {type}");
		}
	}
}