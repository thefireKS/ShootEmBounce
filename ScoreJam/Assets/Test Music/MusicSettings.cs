using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private AudioMixerGroup audioMixerGroup;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleMenu();
    }

    private void ToggleMenu()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            settingsMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            settingsMenu.SetActive(false);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        audioMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void ChangeMusicVolume(float volume)
    {
        audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void ChangeEffectsVolume(float volume)
    {
        audioMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    }
}
