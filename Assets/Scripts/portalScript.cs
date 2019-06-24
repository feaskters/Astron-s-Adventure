using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class portalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button left;
    public Button right;
    public Button up;
    public GameObject winTip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Player")
        {
            AudioManager._instance.playsuccess();

            left.enabled = false;
            right.enabled = false;
            up.enabled = false;
            winTip.GetComponentInChildren<Animator>().SetTrigger("In");

            var level = GameObject.FindGameObjectWithTag("levelInfo").name;
            var int_level = int.Parse(level) + 1;
            if (PlayerPrefs.GetInt("level") < int_level)
            {
                PlayerPrefs.SetInt("level", int_level);
            }
            PlayerPrefs.Save();
        }
    }
}
