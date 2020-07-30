using System.Collections.Generic;
using Assets.Code.Model;
using UnityEngine;

namespace Assets.Code.View
{
    public class StubPlayerView : MonoBehaviour, IPlayerView 
    {
        public int Id { get; set; }
        public float Health { get; set; }
        public void InitStats(List<StatModel> statModels, List<BuffModel> buffModels = null)
        {
        }

        public void Die()
        {
        }

        public void AddStat(IBaseStat baseStat)
        {
        }

        public void ClearStats()
        {
        }
    }
}