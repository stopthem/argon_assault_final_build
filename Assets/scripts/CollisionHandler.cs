using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float levelLoadTime = 0.5f;
    [SerializeField] GameObject deathSeq;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathSeq.SetActive(true);
        Invoke("ReloadScene", levelLoadTime);

    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("PlayerOnDeath", deathSeq);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
