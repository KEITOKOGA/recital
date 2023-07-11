using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public static int AddScore = 0;
    public void Start()
    {
        Score = GetComponent<Text>();
        Score.text = "Score:" + AddScore.ToString();
    }
    public void SetScore_enemy1()
    {
        AddScore += 100;
        Score.text = "Score:" + AddScore.ToString();
    }
    public void SetScore_enemy2()
    {
        AddScore += 200;
        Score.text = "Score:" + AddScore.ToString();
    }

    public void ResetScore()
    {
        AddScore = 0;
    }

    public int GetScore()
    {
        return AddScore;
    }
}