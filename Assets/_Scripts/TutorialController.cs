using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public bool doTutorial = true;


    // Start is called before the first frame update
    void Start()
    {
        if(doTutorial)
        {
            StartCoroutine(tutorial());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tutorial()
    {
        print("tut");
        while (!RatLocomotion.moved)
        {
            print("playing tut");
            AudioPlayer.play(AudioPlayer.Clips.moveTutorial);
            yield return new WaitForSeconds(AudioPlayer.Clips.moveTutorial.length);
        }
        yield return new WaitForSeconds(3f);
        AudioPlayer.play(AudioPlayer.Clips.buttonTutorial);
    }
}
