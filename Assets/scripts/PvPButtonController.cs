using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PvPButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("PvPScene");
    }
}