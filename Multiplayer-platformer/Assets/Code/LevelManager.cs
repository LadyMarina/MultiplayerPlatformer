using System;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    [RequireComponent(typeof(LevelScroller))]
    public class LevelManager : Singleton<LevelManager>
    { 
        public LevelScroller Scroller { get; private set; }

        protected override void OnAwake()
        {
            Scroller = GetComponent<LevelScroller>();
            if (Scroller == null)
            {
                Scroller = gameObject.AddComponent<LevelScroller>();
            }
        }
    }
}