using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager _instance;

    public AudioSource theAS;
    public AudioSource jump;
    public AudioSource button;
    public AudioSource dead;
    public AudioSource success;
    private void Awake() {
        if (_instance == null)
        {
            _instance = this;
        }else if (_instance != this)
        {
            Destroy(gameObject);
        }
        theAS = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playbutton(){
        _instance.button.Play();
    }

    public void playjump(){
        _instance.jump.Play();
    }

    public void playdead(){
        _instance.dead.Play();
    }
    public void playsuccess(){
        _instance.success.Play();
    }
}
