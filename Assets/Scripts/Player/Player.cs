using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;




public class Player : MonoBehaviour
{
    [SerializeField]
    private float moceForce = 5f;

    [SerializeField]
    private float jumpForceLow = 4.5f;

    [SerializeField ]
    private float jumpForceHight = 5.5f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator myAnimator;

    private bool isGround = true;


    private string WALK_ANIMATION = "run";

    private string JUMP_ANIMATION = "jump";

    private string SHOOTUP_ANIMATION = "shootUp";

    private string SHOOTDOWN_ANIMATION = "shootDown";

    private string GROUND_TAG = "ground";

    private string ENEMY_TAG = "Enemy";


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();   

        myAnimator = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * moceForce;
    }

    void AnimatePlayer()
    {

        // if we are going to the right side
        if (movementX > 0)
        {
            myAnimator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if(movementX < 0)
        {
            // if we are going to the left side
            myAnimator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            myAnimator.SetBool(WALK_ANIMATION, false);
        }

        if(myBody.velocity.y != 0)
        {
            myAnimator.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            myAnimator.SetBool(JUMP_ANIMATION, false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            myAnimator.SetBool(SHOOTUP_ANIMATION, true);
        }
        else
        {
            myAnimator.SetBool(SHOOTUP_ANIMATION, false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool(SHOOTDOWN_ANIMATION, true);
        }
        else
        {
            myAnimator.SetBool(SHOOTDOWN_ANIMATION, false);
        }

    }

    private bool isBetterJump = false;
    void PlayerJump()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && !isBetterJump)
        {
            if (isGround)
            {
                isGround = false;
                myBody.AddForce(new Vector2(0, jumpForceLow), ForceMode2D.Impulse);

            }
            else
            {
                isBetterJump = true;
                myBody.AddForce(new Vector2(0, jumpForceHight), ForceMode2D.Impulse);
   
            }
            
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGround = true;
            isBetterJump = false;

        }else if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(collision.gameObject);
            
        }
        //{
        //    Destroy(gameObject);
        //    hitPlayer();
        //}

    }

} // class

