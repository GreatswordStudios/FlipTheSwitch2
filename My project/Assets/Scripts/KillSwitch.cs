using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    string[] playerList = { };
    int playerToKill = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectPlayerToRemove();   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void selectPlayerToRemove()
    {
        if (playerList.Length > 0)
        {
            playerToKill = Random.Range(0, playerList.Length - 1);
        }
    }

    void FlipSwitch(int PlayerEnum, int PTK)
    {
        if (PlayerEnum == PTK)
        {
            myObject.GetComponent<PlayerStatsAndMovement>PlayerStatsAndMovement.
        }
    }
}
