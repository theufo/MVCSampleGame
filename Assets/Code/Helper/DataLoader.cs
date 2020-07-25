using System;
using UnityEngine;

namespace Assets.Code.Helper
{
    public class DataLoader
    {
        public static Data.Data LoadJson()
        {
            var data = Resources.Load<TextAsset>("data");
            if (data == null)
            {
                throw new NullReferenceException("no data", null);
            }
            return JsonUtility.FromJson<Data.Data>(data.text);
        }
    }
}