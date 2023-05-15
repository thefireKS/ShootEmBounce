using LootLocker.Requests;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName;

    [SerializeField] private GameObject nameInputObject;
    [SerializeField] private TMP_InputField nameInput;
    

    [SerializeField] private GameObject fading;
    private Animator _fadeAnimator;
    
    private void Start()
    {
        _fadeAnimator = fading.GetComponent<Animator>();
        
        StartGuestSession();
    }

    private void StartGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            string playerName = "";
            if (response.success)
            {
                PlayerData playerData = FindObjectOfType<PlayerData>();
                playerData.player_id = response.player_id.ToString();
                
                Debug.Log("LootLocker: Guest session started!");
                LootLockerSDKManager.GetPlayerName(response =>
                {
                    playerName = response.name;
                    playerData.playerName = playerName;

                    if (playerName.Length >= 3)
                    {
                        _fadeAnimator.Play("LoadAnim");
                        SceneManager.LoadScene(mainMenuSceneName);
                    }
                    else
                    {
                        _fadeAnimator.Play("LoadAnim");
                        nameInputObject.SetActive(true);
                    }
                });
            }
            else
            {
                Debug.Log($"LootLocker: Guest session NOT started! {response.Error}");
            }
        });
    }

    public void EnterName()
    {
        var playerName = nameInput.text;
        if (playerName == "")
        {
            playerName = $"Player {Random.Range(0, 100000)}";
        }
        LootLockerSDKManager.SetPlayerName(playerName, response => 
        {
            if (response.success)
            {
                PlayerData playerData = FindObjectOfType<PlayerData>();
                playerData.playerName = playerName;
                SceneManager.LoadScene(mainMenuSceneName);
            }
        });
        
    }
}
