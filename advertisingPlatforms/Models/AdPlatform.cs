namespace advertisingPlatforms.Models
{
    public class AdPlatform
    {
        public required string Name { get; set; }
        public required List<string> Locations { get; set; }
    }
}
