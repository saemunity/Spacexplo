using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public int _score;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        if (_score < 10)
        {
            scoreText.text = "0" + _score.ToString();
        }
        else
        {
            scoreText.text = _score.ToString();
        }
    }

    public void AddScore()
    {
        _score++;
    }
}
