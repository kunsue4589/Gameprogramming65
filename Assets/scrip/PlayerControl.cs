using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int PlayerAct;
    private Animator anim;
    
    float playerInput;
    public int speed;

    public int countCoin;
    public Text showCoin;

    private Rigidbody2D playerRigid2D;
    public float jumpVelocity;
    public bool groundCheck;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigid2D = transform.GetComponent<Rigidbody2D>();
        UpadateDataToScene();    
    }

    private void Update()
    {
        SaveDataToGameobject();
        showCoin.text = countCoin.ToString();
        
        playerInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(playerInput,0,0);

        if(playerInput == 0)
        {
            PlayerAct = 1;
        }
        if(playerInput < 0)
        {
            PlayerAct = 0;
            ChangeDirection(-1);
        }
        if(playerInput > 0)
        {
            PlayerAct = 0;
            ChangeDirection(1);
        }

        jumpCheck();
    }
        void SaveDataToGameobject()
        {
            SaveData.coin = countCoin;

        }
        void UpadateDataToScene()
        {
            countCoin = SaveData.coin;
        }
    void jumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck == true)
        {
            playerRigid2D.velocity = Vector2.up *  jumpVelocity;
        }
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
   
    private void FixedUpdate()
    {
        PlayerWalk();
    }
    void PlayerWalk()
    {
        anim.SetInteger("playerAct",PlayerAct);
    }
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            countCoin += 1;
        }
    }
    
    
}
