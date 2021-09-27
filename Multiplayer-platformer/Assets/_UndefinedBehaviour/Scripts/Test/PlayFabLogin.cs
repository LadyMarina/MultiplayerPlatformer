using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace UndefinedBehaviour.MultiplayerPlatformer.PlayFab
{
    public class PlayFabLogin : MonoBehaviour
    {
        public void Awake()
        {
           LogIn();
           Application.quitting += SavePlayFabData;
        }

        public static void LogIn()
        {
            var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        }
        
        private static void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Login successful");
        }
        
        private static void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError("Login error.");
            Debug.LogError(error.GenerateErrorReport());
        }

        private void SavePlayFabData()
        {
            LeaderBoardManager.SendToLeaderboard("TimePlayed", Mathf.RoundToInt(Time.realtimeSinceStartup));
        }
    }
}
