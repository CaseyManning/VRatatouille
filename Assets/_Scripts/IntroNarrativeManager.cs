using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNarrativeManager : MonoBehaviour
{
    public ScriptedIntroEnemy enemy1;
    public ScriptedIntroEnemy enemy2;

    public ScriptedIntern intern;

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
        yield return new WaitForSeconds(10);
        enemy1.leave();
        yield return new WaitForSeconds(1);
        enemy2.leave();
        yield return new WaitForSeconds(3.5f);
        intern.enter();
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("GameScene");
    }
}
