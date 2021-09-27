using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer.PlayFab
{
    public class LeaderBoardManager
    {
        public static void SendToLeaderboard(string leaderBoard, int highScore)
        {
            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = leaderBoard,
                        Value = highScore
                    }
                }
            };
            
            PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnLeaderboardUpdateError);
        }
        
        private static void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
        {
            Debug.Log("Information sent to leaderboard successfully.");
        }

        private static void OnLeaderboardUpdateError(PlayFabError error)
        {
            Debug.Log("Error updating leaderboard");
            Debug.Log(error.GenerateErrorReport());
        }
    }
}