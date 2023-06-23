using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProtoButtonController : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Player3Scene");
    }
}