using PluginFramework.Plugins;

namespace PluginFramework.Services
{
    public class PluginManager
    {
        private readonly Dictionary<string, IImagePlugin> _plugins = new();

        public void LoadPlugin(IImagePlugin plugin)
        {
            if (plugin == null || string.IsNullOrEmpty(plugin.Name))
            {
                throw new System.ArgumentNullException(nameof(plugin), "Plugin or plugin name cannot be null.");
            }

            if (!_plugins.ContainsKey(plugin.Name))
            {
                _plugins[plugin.Name] = plugin;
            }
        }

        public void RemovePlugin(string pluginName)
        {
            if (string.IsNullOrEmpty(pluginName))
            {
                throw new System.ArgumentNullException(nameof(pluginName), "Plugin name cannot be null or empty.");
            }

            if (_plugins.ContainsKey(pluginName))
            {
                _plugins.Remove(pluginName);
            }
        }

        public IImagePlugin GetPlugin(string pluginName)
        {
            if (string.IsNullOrEmpty(pluginName))
            {
                throw new System.ArgumentNullException(nameof(pluginName), "Plugin name cannot be null or empty.");
            }

            return _plugins.ContainsKey(pluginName) ? _plugins[pluginName] : null;
        }

        public IEnumerable<IImagePlugin> GetAllPlugins()
        {
            return _plugins.Values;
        }
    }
}
