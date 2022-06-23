using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        MenuManager.instance.LoadData();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MenuManager.instance.UpdatePlayerName();
    }
    public void Exit()
    {
        EditorApplication.ExitPlaymode();
        
    }
}
