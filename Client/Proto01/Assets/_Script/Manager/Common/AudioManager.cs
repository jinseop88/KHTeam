using UnityEngine;
using System.Collections;


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
	private static string AUDIO_CLIP_PATH_PREFIX = "Prefabs/Sound/";

    private string[] AUDIO_CLIP_PATHS =
    {
            AUDIO_CLIP_PATH_PREFIX + "Attack1",
            AUDIO_CLIP_PATH_PREFIX + "Attack2",
            AUDIO_CLIP_PATH_PREFIX + "Background1",
            AUDIO_CLIP_PATH_PREFIX + "Item_Get",
            AUDIO_CLIP_PATH_PREFIX + "Magic_Notice",
            AUDIO_CLIP_PATH_PREFIX + "Monster_Dead",
            AUDIO_CLIP_PATH_PREFIX + "TouchSound"
    };

    private AudioSource[] audioSources = new AudioSource[(int)AudioClipType.SOUND_COUNT];


    public void PlayAudioClip(AudioClipType audioClipType)
    {
        int index = (int)audioClipType;
        if (audioSources[index] == null)
        {
            audioSources[index] = gameObject.AddComponent<AudioSource>();
            audioSources[index].playOnAwake = false;
			audioSources[index].clip = Resources.Load<AudioClip>(AUDIO_CLIP_PATHS[index]);

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
