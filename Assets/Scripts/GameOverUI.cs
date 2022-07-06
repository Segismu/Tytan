using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreKeeper;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<Score>();
    }
    void Start()
    {
        scoreText.text = "Score\n" + scoreKeeper.GetScore();
    }
}
