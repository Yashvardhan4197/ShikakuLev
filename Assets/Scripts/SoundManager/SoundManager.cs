using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource bgAudio;
    private AudioSource sFXAudio;

    private SoundTypes[] SoundType;

    public SoundManager(AudioSource bgAudio, AudioSource sFXAudio, SoundTypes[] soundType)
    {
        this.bgAudio = bgAudio;
        this.sFXAudio = sFXAudio;
        SoundType = soundType;
    }


    public void PlaySound(SoundNames soundName)
    {
        AudioClip item = GetAudioClip(soundName);
        if(item != null)
        {
            sFXAudio.PlayOneShot(item);
        }
    }

    public void SetupBgSound(SoundNames soundName)
    {
        AudioClip item=GetAudioClip(soundName);
        if(item != null)
        {
            bgAudio.clip = item;
            bgAudio.Play();
        }
    }

    private AudioClip GetAudioClip(SoundNames soundName)
    {
        SoundTypes sound = Array.Find(SoundType, s => s.soundName == soundName);
        if(sound == null)
        {
            return null;
        }
        return sound.AudioClip;
    }
}

[System.Serializable]
public class SoundTypes
{
    public SoundNames soundName;
    public AudioClip AudioClip;
}

public enum SoundNames
{
    BUTTON_CLICK,
    DENY,
    DESELECT,
    GAME_OVER,
    BACKGROUND
}