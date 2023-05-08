using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUI : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GetScreen()
    {
        ScreenshotHandler.TakeScreenshot_Static(500, 500);
    }
}
