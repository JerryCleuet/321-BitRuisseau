using System.Text.Json;

namespace BitRuisseau.Protocol
{
    /// <summary>
    /// Un objet de ce type décrit le catalogue d'une médiathèque
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// la médiathèque dont ceci est le catalogue
        /// </summary>
        public string MediaCenterId { get; set; }

        public List<MediaDescription> Medias { get; set; }

        public override string ToString() => this.ToJson();
        public string ToJson() => JsonSerializer.Serialize(this);
        public static Catalog? FromJson(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<Catalog>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}