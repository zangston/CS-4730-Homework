using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameOverScreen gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.Start();
    }
}
