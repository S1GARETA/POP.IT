using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // private string dirWin = "/Resources/Screenshots";
    // private string dirAndroid = "/storage/emulated/0/PopIt";
    private void Start() 
    {
        // if(!Directory.Exists(Application.dataPath + dirWin)) // For Windows
        // {
        //     System.IO.Directory.CreateDirectory(Application.dataPath + dirWin);
        // }
        if(!Directory.Exists("/storage/emulated/0/PopIt")) // For Android
        {
            Directory.CreateDirectory("/storage/emulated/0/PopIt");
        }
    }
    public void LoadGame(int lvl)
    {
        PlayerPrefs.SetInt("numLvl", lvl);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
