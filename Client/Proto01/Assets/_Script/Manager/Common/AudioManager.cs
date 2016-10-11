using UnityEngine;
using System.Collections;

using UnityEditor;

public enum AudioClipType
{
    ATTACK1,
    ATTACK2,
    BACKGROUND,
    ITEM,
    NOTICE,
    DEAD,
    TOUCH,
    SOUND_COUNT
}

public class AudioManager : SingleTon<AudioManager>
{
    private static string AUDIO_CLIP_PATH_PREFIX = "Assets/Art/Sound/";

    private string[] AUDIO_CLIP_PATHS =
    {
            AUDIO_CLIP_PATH_PREFIX + "Attack1.wav",
            AUDIO_CLIP_PATH_PREFIX + "Attack2.wav",
            AUDIO_CLIP_PATH_PREFIX + "Background1.mp3",
            AUDIO_CLIP_PATH_PREFIX + "Item_Get.mp3",
            AUDIO_CLIP_PATH_PREFIX + "Magic_Notice.wav",
            AUDIO_CLIP_PATH_PREFIX + "Monster_Dead.wav",
            AUDIO_CLIP_PATH_PREFIX + "TouchSound.mp3"
    };

    private AudioSource[] audioSources = new AudioSource[(int)AudioClipType.SOUND_COUNT];


    public void PlayAudioClip(AudioClipType audioClipType)
    {
        int index = (int)audioClipType;
        if (audioSources[index] == null)
        {
            audioSources[index] = gameObject.AddComponent<AudioSource>();
            audioSources[index].playOnAwake = false;
            audioSources[index].clip = AssetDatabase.LoadAssetAtPath<AudioClip>(AUDIO_CLIP_PATHS[index]);

            if (audioClipType == AudioClipType.BACKGROUND)
            {
                audioSources[index].loop = true;
            }
        }

        if (!audioSources[index].isPlaying)
        {
            audioSources[index].Play();
        }
    }
}
