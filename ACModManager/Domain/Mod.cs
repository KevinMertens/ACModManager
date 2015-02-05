namespace ACModManager.Domain
{
    public class Mod
    {
        public string Name { get; set; }
        public ModTypes Type { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}