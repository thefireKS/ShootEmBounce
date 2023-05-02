using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName;
    private void Start()
    {
        StartGuestSession();
    }

    private void StartGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("LootLocker: Guest session started!");
                SceneManager.LoadScene(mainMenuSceneName);
            }
            else
            {
                Debug.Log($"LootLocker: Guest session NOT started! {response.Error}");
            }
        });
    }
}
