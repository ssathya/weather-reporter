namespace Weather.Models
{
    public class Sys
    {
        #region Public Properties

        public string country { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public int type { get; set; }

        #endregion Public Properties
    }
}