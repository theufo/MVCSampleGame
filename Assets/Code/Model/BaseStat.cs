﻿namespace Assets.Code.Model
{
    public abstract class BaseStat : IBaseStat
    {
        public int PlayerId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}