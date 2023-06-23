using System;
using UnityEngine;

public class command : MonoBehaviour
{
    public GameObject ProtoButton;
    int cmd1Seq = 0;
    int[] keyCodes1;
    int[] konamiCommand = new[] {
        (int)KeyCode.UpArrow,
        (int)KeyCode.UpArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.A,
        (int)KeyCode.B
    };
    int kcnt = 0;
    private void Start()
    {
        keyCodes1 = (int[])Enum.GetValues(typeof(KeyCode));
    }
    void Update()
    {
        var com1 = keyCodes1.Length;
        for (var i = 0; i < com1; i++)
        {
            if (Input.GetKeyUp((KeyCode)keyCodes1[i]))
            {
                if (konamiCommand[cmd1Seq] == keyCodes1[i])
                {
                    cmd1Seq++;
                    if (cmd1Seq == konamiCommand.Length)
                    {
                        kcnt++;
                        ProtoButton.SetActive(true);
                        cmd1Seq = 0;
                    }
                }
                else
                {
                    cmd1Seq = 0;
                }
            }
        }
    }

}