using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    static AudioSource source;

    public AudioClip ouch;
    public AudioClip moveTutorial;
    public AudioClip buttonTutorial;
    public AudioClip monitorsDialogue1;
    public AudioClip monitorsDialogue2;
    public AudioClip talkingInElevator;
    public AudioClip beforeElevator;
    public AudioClip elevatorDing;
    public AudioClip outroEnemyDialogue;

    public static AudioPlayer Clips;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Clips = this;
    }

    // Update is called once per frame

    public static void play(AudioClip clip)
    {
        if (clip)
        {
            source.PlayOneShot(clip);
        } else
        {
            print("missing audio clip");
        }
    }
}
