using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Player2Scene");
    }
}