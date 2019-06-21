using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button back;
    void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        var enabel_level = PlayerPrefs.GetInt("level");
        back.onClick.AddListener(delegate {buttonClick("back");});
        var buttons = transform.GetComponentsInChildren<Button>();
        foreach (var item in buttons)
        {   
            var text = item.transform.Find("1");
            if (text != null)
            {
                var message = text.GetComponent<Text>().text;
                item.onClick.AddListener(delegate {buttonClick(message);});
                item.enabled = false;
                item.interactable = false;
                if (enabel_level > 0)
                {
                    item.enabled = true;
                    item.interactable = true;
                    enabel_level --;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buttonClick(string message){
        if (message == "back")
        {
            SceneManager.LoadScene("MainScene");
        }else{
            SceneManager.LoadScene(message + "level");
        }
    }
}
