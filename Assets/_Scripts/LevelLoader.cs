using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public string levelToLoad = "lab maze";
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
