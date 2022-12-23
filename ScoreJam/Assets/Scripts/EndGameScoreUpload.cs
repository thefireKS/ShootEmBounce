using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class EndGameScoreUpload : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField playerNameInputField;

    [SerializeField] 
    private TextMeshProUGUI totalScore;

    [SerializeField]
    private ScorePoints scp;

    private string _leaderboardKey = "highscoreBoard";

    private void Start()
    {
        totalScore.text = "Your score is:" + scp.score;
    }

    public void UploadScore()
    {
        //Generic leaderboard, 
         //metadata is used for the name and a unique identifier tied to the memberID
         //is used for a player to upload as many scores as they want with any name they want
         //ensuring that every new score gets its' own post on the leaderboard.
         
         string infiniteScores = MainMenuScoreSetup.memberID;
        LootLockerSDKManager.SubmitScore(infiniteScores, scp.score, _leaderboardKey, playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                
            }
        });
    }
}
