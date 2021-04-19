using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zad5_Net.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
