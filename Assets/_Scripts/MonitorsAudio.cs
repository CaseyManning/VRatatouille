using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorsAudio : MonoBehaviour
{
    bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !played)
        {
            print("playing monitor audio");
            played = true;
            AudioPlayer.play(AudioPlayer.Clips.monitorsDialogue1);
        }
    }
}
