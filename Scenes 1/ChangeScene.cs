using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scene;

    public void Start()
    {
        Debug.Log("Загрузчик сцен готов");
    }
    public void LS(int scene)
    {
        Debug.Log("Загружена сцена №" + scene);
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
