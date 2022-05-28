using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNarrativeManager : MonoBehaviour
{
    public ScriptedIntroEnemy enemy1;
    public ScriptedIntroEnemy enemy2;

    public ScriptedIntern intern;

    public AudioClip enemiesConversation;
    public AudioClip internCoversation;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(narrative());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator narrative()
    {
        yield return new WaitForSeconds(0.5f);
        if (enemiesConversation)
        {
            source.PlayOneShot(enemiesConversation);
            yield return new WaitForSeconds(enemiesConversation.length + 1);
        }
        enemy1.leave();
        yield return new WaitForSeconds(1);
        enemy2.leave(); 
        yield return new WaitForSeconds(3.5f);
        intern.enter();
        yield return new WaitForSeconds(3f);
        if (internCoversation)
        {
            source.PlayOneShot(internCoversation);
            yield return new WaitForSeconds(internCoversation.length + 1);
        }
        SceneManager.LoadScene("GameScene");
    }
}
