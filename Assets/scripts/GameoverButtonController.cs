using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("GameoverScene") ;
    }
}