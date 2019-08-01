using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text wintext;
    public Text buttonback;
    public Font customFont;
    public Text failText;
    public Text restartText;
    void Start()
    {
        var restart_btn = transform.GetComponentsInChildren<Button>();
        foreach (var item in restart_btn)
        {
            if (item.name == "restart")
            {
                item.onClick.AddListener(restart);
            }else if (item.name == "back")
            {
                item.onClick.AddListener(back);
            }
        }
        string language = Application.systemLanguage.ToString();
        if (language == "Chinese" || language == "cn" || language == "ChineseSimplified")
        {
            if (wintext != null)
            {
                wintext.text = "关卡 通过";
                wintext.font = customFont;
            }

            if (failText != null)
            {
                failText.text = "游戏 结束";
                failText.font = customFont;
            }
            
            if (restartText != null)
            {
                restartText.text = "重新开始";
                restartText.font = customFont;
            }

            buttonback.text = "返回";
            buttonback.font = customFont;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void back(){
        SceneManager.LoadScene("LevelScene");
    }
}
