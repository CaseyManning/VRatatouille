using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    static AudioSource source;

    public class Clips
    {
        public static AudioClip ouch;
        public static AudioClip moveTutorial;
        public static AudioClip buttonTutorial;
        public static AudioClip monitorsDialogue1;
        public static AudioClip monitorsDialogue2;
    }

    public AudioClip ouch;
    public AudioClip moveTutorial;
    public AudioClip buttonTutorial;
    public AudioClip monitorsDialogue1;
    public AudioClip monitorsDialogue2;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioPlayer.Clips.ouch = ouch;
        AudioPlayer.Clips.moveTutorial = moveTutorial;
        AudioPlayer.Clips.buttonTutorial = buttonTutorial;
        AudioPlayer.Clips.monitorsDialogue1 = monitorsDialogue1;
        AudioPlayer.Clips.monitorsDialogue2 = monitorsDialogue2;
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
