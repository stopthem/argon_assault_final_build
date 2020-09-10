using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class splashload : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float levelLoadTime = 5f;

    void Start()
    {
        Invoke("LoadNextLevel", levelLoadTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
        
    }
}
