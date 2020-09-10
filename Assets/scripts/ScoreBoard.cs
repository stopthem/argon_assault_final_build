using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreText;
    int score;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        
    }

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();

    }
}
