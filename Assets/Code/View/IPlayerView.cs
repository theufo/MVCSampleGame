using Assets.Code.Model;

namespace Assets.Code.View
{
    public interface IPlayerView
    {
        int Id { get; set; }
        float Health { get; set; }
        void Die();
        void AddStat(IBaseStat baseStat);
        void ClearStats();
    }
}