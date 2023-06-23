using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class command2 : MonoBehaviour
{
    public GameObject PvPButton;
    int cmd2Seq = 0;
    int[] keyCodes2;
    int[] PvPON = new[]
    {
        (int)KeyCode.P,
        (int)KeyCode.V,
        (int)KeyCode.P,
        (int)KeyCode.M,
        (int)KeyCode.O,
        (int)KeyCode.D,
        (int)KeyCode.E,
        (int)KeyCode.O,
        (int)KeyCode.N
    };
    int co2 = 0;
    // Start is called before the first frame update
    private void Start()
    {
        keyCodes2 = (int[])Enum.GetValues(typeof(KeyCode));
    }

    // Update is called once per frame
    void Update()
    {
        var com2 = keyCodes2.Length;
        for (var j = 0; j < com2; j++)
        {
            if (Input.GetKeyUp((KeyCode)keyCodes2[j]))
            {
                if (PvPON[cmd2Seq] == keyCodes2[j])
                {
                    cmd2Seq++;
                    if (cmd2Seq == PvPON.Length)
                    {
                        co2++;
                        PvPButton.SetActive(true);
                        cmd2Seq = 0;
                    }
                }
                else
                {
                    cmd2Seq = 0;
                }
            }
        }

    }
}
