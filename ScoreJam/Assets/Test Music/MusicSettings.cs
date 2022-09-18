using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    
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