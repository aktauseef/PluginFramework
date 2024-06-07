namespace PluginFramework.RequestModels
{
    public class ImageProcessingRequest
    {
        public List<Effect> Effects { get; set; }
    }

    public class Effect
    {
        public string PluginName { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
