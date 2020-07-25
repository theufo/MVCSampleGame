using Assets.Code.Model;
using UnityEngine;

namespace Assets.Code.Helper
{
    public static class StatImageLoader
    {
        public static Sprite LoadStatImage(IBaseStat statModel)
        {
                return Resources.Load<Sprite>($"Icons/{statModel.Icon}");
        }
    }
}