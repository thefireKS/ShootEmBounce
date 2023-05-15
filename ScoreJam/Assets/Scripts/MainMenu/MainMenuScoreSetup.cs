using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class MainMenuScoreSetup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardTop10Text_Name;
    [SerializeField] private TextMeshProUGUI currentRankText;

    [SerializeField] private TextMeshProUGUI[] members;
    
    [SerializeField] private string[] leaderboardKeys;
    private int _currentLeaderboard;

    private void Start()
    {
        UpdateCurrentRank();
        UpdateLeaderboardTop10(leaderboardKeys[0]);
    }
    
    public void ChangeLeaderboard(int step)
    {
        _currentLeaderboard += step;
        
        if (_currentLeaderboard >= leaderboardKeys.Length)
        {
            _currentLeaderboard = 0;
        }

        if (_currentLeaderboard < 0)
        {
            _currentLeaderboard = leaderboardKeys.Length - 1;
        }
        
        UpdateLeaderboardTop10(leaderboardKeys[_currentLeaderboard]);
    }

    public void UpdateLeaderboardTop10(string leaderboardKey)
    {
        switch (leaderboardKey)
        {
            case ("TotalLeaderboard"):
            {
                leaderboardTop10Text_Name.text = "TOP 10 BALLOON POPPERS";
                break;
            }
            case ("ToyMachineLeaderboard"):
            {
                leaderboardTop10Text_Name.text = "TOP 10 'TOY MACHINE'";
                break;
            }
            case ("CanyonLeaderboard"):
            {
                leaderboardTop10Text_Name.text = "TOP 10 'CANYON'";
                break;
            }
            case ("PrototypeLeaderboard"):
            {
                leaderboardTop10Text_Name.text = "TOP 10 'PROTOTYPE'";
                break;
            }
            default:
            {
                leaderboardTop10Text_Name.text = "Miss";
                break;
            }
        }

        foreach (var member in members)
        {
            member.text = "";
        }
        
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
        {
            if (response.success)
            {
                for (int i = 0; i < response.items.Length; i++)
                {
                    LootLockerLeaderboardMember currentEntry = response.items[i];
                    string leaderboardText = $"{currentEntry.rank}# {currentEntry.metadata} — {currentEntry.score}";
                    members[i].text = leaderboardText;
                }
            }
        });
    }

    private void UpdateCurrentRank()
    {
        LootLockerSDKManager.GetMemberRank("TotalLeaderboard", FindObjectOfType<PlayerData>().player_id, (response) =>
        {
            if (response.success)
            {
                if (response.rank == 0 || response.score == 0)
                {
                    currentRankText.text = "No current rank";
                }
                else
                {
                    currentRankText.text = $"#{response.rank} — {FindObjectOfType<PlayerData>().playerName} — {response.score}";
                }
            }
        });
    }
}
