namespace Assets.Code.Model
{
    public class SettingsModel
    {
        public int PlayersCount{ get; set; }
        public int BuffCountMin { get; set; }
        public int BuffCountMax { get; set; }
        public bool AllowDuplicateBuffs { get; set; }
        public bool WithBuffs { get; set; }
    }
}