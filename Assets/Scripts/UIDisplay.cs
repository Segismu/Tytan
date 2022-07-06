using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] Slider hpSlider;
    [SerializeField] HP playerHP;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<Score>();
    }

    void Start()
    {
        hpSlider.maxValue = playerHP.GetHP();
    }


    void Update()
    {
        hpSlider.value = playerHP.GetHP();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");   
    }
}
