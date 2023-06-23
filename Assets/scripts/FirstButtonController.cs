using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Player1Scene");
    }
}