using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipScript : MonoBehaviour
{
    public Text tipText;
    public Text continueText;
    public Font customFont;
    // Start is called before the first frame update
    public Button con;
    void Start()
    {
        con.onClick.AddListener(onClick);

        string language = Application.systemLanguage.ToString();
        if (language == "Chinese" || language == "cn" || language == "ChineseSimplified")
        {
            if (tipText != null)
            {
                tipText.text = "我需要想办法离开这里！";
                tipText.font = customFont;
            }

            if (continueText != null)
            {
                continueText.text = "继续";
                continueText.font = customFont;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        transform.GetComponentInChildren<Animator>().SetTrigger("continue");
    }

}
