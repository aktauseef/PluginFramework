using PluginFramework.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace PluginFramework.Plugins
{
    public class DummyPlugin : IImagePlugin
    {
        public string Name => "DummyPlugin";

        public void Apply(ref DummyImage image, Dictionary<string, object> parameters)
        {
            Console.WriteLine("Applying DummyPlugin with parameters: " + string.Join(", ", parameters));
        }
    }
}
