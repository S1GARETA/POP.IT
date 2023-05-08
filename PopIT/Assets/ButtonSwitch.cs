using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ButtonSwitch : MonoBehaviour
{
    private Button level;
    private string imgPath = "Assets/Screenshots/lvl_";
    public string numLvl;
    void Start()
    {
        var img = transform.GetChild(1).gameObject.GetComponent<Image>();
        img.sprite = LoadTexture2Sprite();
    }

    private Sprite LoadTexture2Sprite()
    {
        var filePath = imgPath + numLvl + ".png";

        Texture2D t2d = new Texture2D(1920, 1080);
        // Согласно Road King, читаем поток байтов и преобразуем его в картинку
        t2d.LoadImage(getImageByte(filePath));
        // Создаем текстуру в Sprite. Параметры являются исходными файлами изображения, а значение Rect дает начальную точку, размер и положение точки привязки.
        Sprite sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), Vector2.zero);
        return sprite;
    }

    private byte[] getImageByte(string imagePath)
    {
        // Чтение в файл
        FileStream files = new FileStream(imagePath, FileMode.Open);
        // Создать новый объект битового потока
        byte[] imgByte = new byte[files.Length];
        // Записать файл в соответствующий объект потока битов
        files.Read(imgByte, 0, imgByte.Length);
        // Закрыть файл
        files.Close();
        // Возвращаем значение битового потока
        return imgByte;
    }
}
