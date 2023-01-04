using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YoutubeVideoDownloader.Models.Convert
{
    public class CustomJsonConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(YoutubeVideo);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            YoutubeVideo myObject = new YoutubeVideo();
            myObject.VideoUrl = (string)jo["uri"];
            myObject.VideoName = (string)jo["fullName"];
            myObject.Resolution = (string)jo["resolution"];
            myObject.Format = (string)jo["fileExtension"];
            return myObject;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}