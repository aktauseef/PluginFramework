using PluginFramework.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace PluginFramework.Plugins
{
    public interface IImagePlugin
    {
        string Name { get; }
        void Apply(ref DummyImage image, Dictionary<string, object> parameters);
    }
}
