namespace Weather.Models
{
    public class OpenWeatherResponse
    {
        #region Public Properties

        public string _base { get; set; }
        public Clouds clouds { get; set; }
        public int cod { get; set; }
        public Coord coord { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public Main main { get; set; }
        public string name { get; set; }
        public Sys sys { get; set; }
        public int visibility { get; set; }
        public Weather[] weather { get; set; }
        public Wind wind { get; set; }

        #endregion Public Properties
    }
}