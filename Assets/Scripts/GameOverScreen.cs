using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PiratesLifeButton()
    {
        SceneManager.LoadScene("pirates-life");
    }

    public void BackToMainLevelButton()
    {
        SceneManager.LoadScene("unity1-zangston");
    }
}
