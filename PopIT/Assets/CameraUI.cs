using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraUI : MonoBehaviour
{
    public GameObject[] objSphere; // Префабы сфер
    public GameObject[] prefabLevel; // Уровни
    public Sprite[] spritesLvl; // Готовые спрайты для уровня
    public Image[] canvasImg;
    private GameObject nextReady;
    public AnimationCurve curve; // Проявление изображения
    public static int countSphere = 4; // Количество сфер на сцене
    public static Action onNextLeveled; // Уничтожение Solver
    public static Func<int, Sprite> onGetSprited; // Конвертер изображения
    private float time;
    private Dictionary<int, int> numLvl = new Dictionary<int, int>()
    {
        {1, 7},
        {2, 6},
        {3, 7}
    };

    void Start() 
    {  
        DefaultSetting();
    }
    void Update() 
    {
        if(countSphere==0) // После лопанья всех шариков меняется прозрачность картины и делается скрин
        {
            Invoke("GetScreen", 3);
            Invoke("ReadyLevel", 3.5f);
            StartCoroutine(ChangeAlpha());
            countSphere = 4;
        }
    }
    public void LoadLevel()
    {
        Instantiate(prefabLevel[PlayerPrefs.GetInt("numLvl")-1]);
        countSphere = numLvl[PlayerPrefs.GetInt("numLvl")];
    }
    public void Create() // Создаёт новые сферы по кнопке "создать" (Будут загружаться уровни)
    {
        foreach(var sp in objSphere)
        {
            Instantiate(sp, new Vector3(RandomNumber(), 1, RandomNumber()), Quaternion.Euler(0, 0, 0));
        }
        countSphere = 4;
    }
    public void DefaultSetting() // Начальные настройки при загрузке уровня
    {
        nextReady = GameObject.Find("BlackPanel");
        nextReady.SetActive(false);
        
        canvasImg[0].sprite = spritesLvl[PlayerPrefs.GetInt("numLvl")-1];
        canvasImg[0].color = new Color(1, 1, 1, 0);
        canvasImg[1].sprite = spritesLvl[PlayerPrefs.GetInt("numLvl")-1];
        // Create();
        LoadLevel();
    }
    public IEnumerator ChangeAlpha() // Меняется прозрачность
    {
        float t = 3f;

        while (t > 0f)
        {
            t -= Time.deltaTime* 1f;
            float a = curve.Evaluate(t);
            canvasImg[0].color = new Color (1f, 1f, 1f, a);
            yield return 0;
        }
    }
    public void ReadyLevel() // Уровень закончился
    {
        Sprite sp = onGetSprited?.Invoke(PlayerPrefs.GetInt("numLvl"));
        
        
        if(PlayerPrefs.GetInt("numLvl") == spritesLvl.Length)
        {
            nextReady.SetActive(true);
            canvasImg[2].enabled = true;
            canvasImg[2].sprite = sp;
            GameObject but = GameObject.Find("Next");
            but.SetActive(false);
        }
        else
        {
            nextReady.SetActive(true);
            canvasImg[2].enabled = true;
            canvasImg[2].sprite = sp;
            GameObject but = GameObject.Find("Menu");
            but.SetActive(false);
        }
        
    }
    public void NextLevel() // Переход на следующий уровень
    {
        // onNextLeveled?.Invoke();
        PlayerPrefs.SetInt("numLvl", PlayerPrefs.GetInt("numLvl") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu() // Загрузка главного меню
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GetScreen() // Получение скриншота
    {
        ScreenshotHandler.TakeScreenshot_Static(1080, 1080);
    }
    
    private float RandomNumber() // Просто рандом появления сфер
    {
        return UnityEngine.Random.Range(-3, 3);
    }
}
