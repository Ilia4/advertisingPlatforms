using advertisingPlatforms.Models;

namespace advertisingPlatforms.Services
{
    public class AdPlatformServices
    {
        private List<AdPlatform> _platforms = new();

        public void LoadFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var result = new List<AdPlatform>();

            foreach (var line in lines)
            {
                var parts = line.Split(':');

                if (parts.Length != 2)
                    continue;

                var name = parts[0].Trim();
                var locations = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

                result.Add(new AdPlatform { Name = name, Locations = locations });
            }

            _platforms = result;
        }

        public List<string> Search(string locations)
        {
            return _platforms.Where(p => p.Locations.Any(i => locations.StartsWith(i))).Select(p => p.Name).ToList();
        }
    }
}
