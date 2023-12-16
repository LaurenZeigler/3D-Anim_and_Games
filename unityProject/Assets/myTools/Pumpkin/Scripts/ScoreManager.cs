using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float Score;


    // Start is called before the first frame update
    void Start()
    {
        textScore.text = Score.ToString() + "Score: ";
        Score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score: " + Score.ToString();
    }
}
