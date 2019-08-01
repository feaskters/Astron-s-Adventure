using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLanguageController : MonoBehaviour
{
    public Text title;
    public Text button;
    public Font customFont;
    // Start is called before the first frame update
    void Start()
    {
        string language = Application.systemLanguage.ToString();
        if (language == "Chinese" || language == "cn" || language == "ChineseSimplified")
        {
            button.text = "开始游戏";
            button.font = customFont;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
