using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaraokeMinigameManager : MonoBehaviour
{
    [SerializeField] AudioSource BackGroundMusic;
    [SerializeField] AudioSource PressedSFX;
    [SerializeField] bool isStartPlay;
    [SerializeField] BeatScroller beatScroller;

    public static KaraokeMinigameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartPlay)
        {
            if (Input.anyKeyDown)
            {
                isStartPlay = true;
                beatScroller.hasStarted = true;

                if (BackGroundMusic)
                {
                    BackGroundMusic.Play();
                }
            }
                
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        PressedSFX.Play();
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
