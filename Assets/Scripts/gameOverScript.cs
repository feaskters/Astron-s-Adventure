using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
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
