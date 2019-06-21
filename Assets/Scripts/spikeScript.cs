using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    // Start is called before the first frame update
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
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Animator>().SetTrigger("astron_death");
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<buttonScripts>().invalidate_button();
        }
    }
}
