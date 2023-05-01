using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class MainMenuScoreSetup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI leaderboardTop10Text;
    [SerializeField]
    private TextMeshProUGUI currentRankText;
    
    private string leaderboardKey = "highscoreBoard";

    public static string memberID;
    // Start is called before the first frame update
    void Start()
    {
        StartGuestSession();
    }
    
    private void StartGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                //infoText.text = "Guest session started";
                memberID = response.player_id.ToString();
                UpdateLeaderboardTop10();
                UpdateCurrentRank();
            }
        });
    }
    
    void UpdateLeaderboardTop10()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
        {
            if (response.success)
            {
                string leaderboardText = "";
                for (int i = 0; i < response.items.Length; i++)
                {
                    LootLockerLeaderboardMember currentEntry = response.items[i];
                    leaderboardText += currentEntry.rank + ".";
                    leaderboardText += currentEntry.metadata;
                    leaderboardText += " - ";
                    leaderboardText += currentEntry.score;
                    leaderboardText += "\n";
                }
                leaderboardTop10Text.text = leaderboardText;
            }
        });
    }

    void UpdateCurrentRank()
    {
        LootLockerSDKManager.GetMemberRank(leaderboardKey, memberID, (response) =>
        {
            if (response.success)
            {
                if (response.rank == 0 || response.score == 0) 
                    currentRankText.text = "No current rank";
                else 
                    currentRankText.text = "Your rank is:" + response.rank + " - " + response.score;
            }
        });
    }
}
