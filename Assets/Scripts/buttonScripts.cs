using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    static bool isGround = true;
    float speed = 5;
    public Button back;
    public GameObject gameOverTip;
    public Button left;
    public Button right;
    public Button up;

    float jumpforce = 400f;
    GameObject player;
    Camera mainCamera;
    //相机与人物的初始距离
    Vector2 distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        distance = mainCamera.transform.position - player.transform.position;
        back.onClick.AddListener(() => {SceneManager.LoadScene("LevelScene");AudioManager._instance.playbutton();});
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft && left.enabled)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
            player.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (isRight && right.enabled){
            player.GetComponent<SpriteRenderer>().flipX = false;
            player.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        mainCamera.transform.position = new Vector3(player.transform.position.x + distance.x, player.transform.position.y + distance.y,mainCamera.transform.position.z);
        player.GetComponent<Animator>().SetBool("isJumping", !isGround);
        if (player.transform.position.y < -10)
        {
            player.GetComponent<Animator>().SetTrigger("astron_death");
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            invalidate_button();
        }
    }

    public void onPointDown(string name){
        switch (name)
        {
            case "left":
                isLeft = true;
            break;
            case "right":
                isRight = true;
            break;
            case "up":
                if (isGround && up.enabled)
                {
                    AudioManager._instance.playjump();
                    isGround = false;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce));
                }
            break;
            default:
            break;
        }
        
    }

    public void onPointUp(string name){
        switch (name)
        {
            case "left":
                isLeft = false;
            break;
            case "right":
                isRight = false;
            break;
            default:
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "ground")
        {
            isGround = true;
        }
    }

    public void fail(){
        left.enabled = false;
        right.enabled = false;
        up.enabled = false;
        Destroy(player);
        gameOverTip.GetComponentInChildren<Animator>().SetTrigger("In");
    }

    public void invalidate_button(){
        left.enabled = false;
        right.enabled = false;
        up.enabled = false;
    }

}
