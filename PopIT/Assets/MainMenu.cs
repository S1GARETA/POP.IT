using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame(int lvl)
    {
        PlayerPrefs.SetInt("numLvl", lvl);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
