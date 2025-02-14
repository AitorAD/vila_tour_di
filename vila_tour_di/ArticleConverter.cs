using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vila_tour_di.Models;

namespace vila_tour_di.Converters {
    public class ArticleConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Article);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject jsonObject = JObject.Load(reader);
            string type = jsonObject["type"]?.ToString();

            Article article;

            switch (type) {
                case "festival":
                    article = new Festival();
                    break;
                case "recipe":
                    article = new Recipe();
                    break;
                case "place":
                    article = new Place();
                    break;
                default:
                    throw new InvalidOperationException($"Unknown type: {type}");
            }

            serializer.Populate(jsonObject.CreateReader(), article);
            return article;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            serializer.Serialize(writer, value);
        }
    }
}
