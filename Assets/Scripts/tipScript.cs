using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button con;
    void Start()
    {
        con.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        transform.GetComponentInChildren<Animator>().SetTrigger("continue");
    }

}
