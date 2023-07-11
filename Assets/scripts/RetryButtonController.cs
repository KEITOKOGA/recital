using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("TitleScene");
        if (FindObjectOfType<ScoreManager>().GetScore() != 0)
        {
            FindObjectOfType<ScoreManager>().ResetScore();
        }
    }
}