using System.Collections.Generic;
using Assets.Code.Model;

namespace Assets.Code.View
{
    public interface IPlayerView
    {
        int Id { get; set; }
        float Health { get; set; }
        void InitStats(List<StatModel> statModels, List<BuffModel> buffModels = null);
        void Die();
    }
}