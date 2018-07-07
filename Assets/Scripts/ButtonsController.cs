using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void Restart(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
