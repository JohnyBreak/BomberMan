using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDB", menuName = "Sound/AudioDB")]
public class AudioDB : ScriptableObject
{
    public SoundCategory[] AudioCategories;

    public AudioClip GetClip(string name) 
    {
        foreach (var category in AudioCategories) 
        {
            if (category.Name == name) 
            {
                return category.AudioClips[0];
            }
        }

        return null;
    }

    public AudioClip[] GetAllClips(string name)
    {
        foreach (var category in AudioCategories)
        {
            if (category.Name == name)
            {
                return category.AudioClips;
            }
        }

        return null;
    }
}

[Serializable]
public struct SoundCategory 
{
    public string Name;
    public AudioClip[] AudioClips;
}