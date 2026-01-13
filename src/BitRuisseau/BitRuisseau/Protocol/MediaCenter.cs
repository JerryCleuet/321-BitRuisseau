using System.Text.Json;

namespace BitRuisseau.Protocol
{
    /// <summary>
    /// Un objet de ce type décrit une médiathèque,
    /// dans le but de pouvoir l'afficher dans une médiathèque distante
    /// </summary>
    public class MediaCenter
    {
        /// <summary>
        /// identifiant unique permettant de distinguer les médiathèques présente sur le réseau
        /// </summary>
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public override string ToString() => this.ToJson();
        public string ToJson() => JsonSerializer.Serialize(this);
        public static MediaCenter? FromJson(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<MediaCenter>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}