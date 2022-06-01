using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroElevator : MonoBehaviour
{
    float moved = 0;

    public GameObject leftDoor;
    public GameObject rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sequence()
    {
        yield return new WaitForSeconds(1);
        AudioPlayer.play(AudioPlayer.Clips.elevatorDing);
        while (moved < 1.9f)
        {
            float move = Time.deltaTime / 1.5f;
            moved += move;
            leftDoor.transform.position += Vector3.right * move;
            rightDoor.transform.position -= Vector3.right * move;

            yield return new WaitForEndOfFrame();
        }
        AudioPlayer.play(AudioPlayer.Clips.outroEnemyDialogue);
    }
}
