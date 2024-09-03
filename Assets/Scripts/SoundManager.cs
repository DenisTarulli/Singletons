using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
        Debug.Log($"Sound: {clip} played at position {position}");
    }
}
