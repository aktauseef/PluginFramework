using PluginFramework.RequestModels;
using PluginFramework.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace PluginFramework.Services
{
    public class ImageProcessor
    {
        private readonly PluginManager _pluginManager;

        public ImageProcessor(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public void ApplyEffects(DummyImage image, List<Effect> effects)
        {
            foreach (var effect in effects)
            {
                Console.WriteLine($"Applying plugin: {effect.PluginName}");

                if (string.IsNullOrEmpty(effect.PluginName))
                {
                    throw new ArgumentNullException(nameof(effect.PluginName), "Plugin name cannot be null or empty.");
                }

                var plugin = _pluginManager.GetPlugin(effect.PluginName);
                if (plugin == null)
                {
                    throw new Exception($"Plugin not found: {effect.PluginName}");
                }

                plugin.Apply(ref image, effect.Parameters);
            }
        }
    }
}
