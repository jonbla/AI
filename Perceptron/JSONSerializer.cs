using System;
using System.Text.Json;
using Perceptron;

namespace IO
{
	public class JSONSerializer
	{
		public JSONSerializer()
		{
		}

		public void DumpToFile(object thing, string filePath, bool isIndented = false)
		{
            JsonSerializerOptions JSONoptions = new JsonSerializerOptions();
            JSONoptions.WriteIndented = isIndented;
            string jsonString = JsonSerializer.Serialize(thing, options: JSONoptions);
            File.WriteAllText(filePath, jsonString);
        }
	}
}

