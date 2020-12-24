using System;
using UnityEngine;

namespace Assets.Code.Data
{
    public class DataLoader
    {
        public static Code.Data.Data LoadJson()
        {
            var data = Resources.Load<TextAsset>("data");
            if (data == null)
            {
                throw new NullReferenceException("no data", null);
            }
            return JsonUtility.FromJson<Code.Data.Data>(data.text);
        }
    }
}