using System;
using PlayFab;
using UndefinedBehaviour.MultiplayerPlatformer.PlayFab;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            Invoke("UpdateLeaderboard", 3);
        }

        /// <summary>
        /// This is only for testing purposes.
        /// </summary>
        private void UpdateLeaderboard()
        {
            LeaderBoardManager.SendToLeaderboard("LongestTime", 10);
        }
    }
}