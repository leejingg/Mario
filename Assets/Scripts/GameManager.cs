using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int coins { get; private set; }
    public int lives { get; private set; }

    private void NewGame()
    {
        lives = 3;
        coins = 0;
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            AddLive();
            coins = 0;
        }
    }

    public void AddLive()
    {
        lives++;
    }
}
