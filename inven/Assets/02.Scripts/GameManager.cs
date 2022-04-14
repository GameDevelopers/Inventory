using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Startgame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Exitgame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }
    }


}
