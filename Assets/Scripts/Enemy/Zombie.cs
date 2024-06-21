using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : Enemy
{
    public float JumpForce;
    public Vector3 targetLeft;
    public Vector3 targetRight;
    private Rigidbody2D rg;
    private Animator myAnimator;
    private int option = -1;
    private bool isAttack = false;
    public bool _isAttack()
    {
        return isAttack;
    }
    Vector3 currentScale;
    Vector3 _currentScale;
    private bool isMove = false;
    public bool _isMove()
    {
        return isMove;
    }
    private bool ZombieEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindWithTag("Player");
        rg = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        rg.mass = 10f;
        //JumpAttack();
        currentScale = transform.localScale;
        _currentScale = transform.localScale;
        _currentScale.x = currentScale.x * -1;


    }

    void Update()
    {
        if (ZombieEnable)
        {
            StartCoroutine(ZombieController());
        }

        AnimateZombie();
    }



    IEnumerator ZombieController()
    {
        ZombieEnable = false;
        option = Random.Range(0, 3); 
        switch (option)
        {
            case 0:
                if (!isAttack)
                {
                    yield return ZombieJump();
                }
                break;
            case 1:
                isMove = true;
                yield return MoveToTarget(targetLeft);
                break;
            case 2:
                isMove = true;
                yield return MoveToTarget(targetRight);
                break;
        }

        yield return new WaitForSeconds(5f);
    }
    IEnumerator turnOn(float time)
    {
        yield return new WaitForSeconds(time);
        ZombieEnable = true;

    }
    IEnumerator ZombieJump()
    {
        isAttack = true;
        yield return Jump();
        isAttack = false;
    }

    IEnumerator Jump()
    {
        for (int i = 0; i < 3; i++)
        {
            rg.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
            yield return new WaitForSeconds(2.5f);
        }

        yield return turnOn(4f);
    }

    IEnumerator MoveToTarget(Vector3 target)
    {

        while (Vector3.Distance(transform.position, target) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
        transform.position = target;
        if (target.x != targetLeft.x)
        {
            transform.localScale = currentScale;
        }
        else
        {
            transform.localScale = _currentScale;
        }
        isMove = false;

        yield return turnOn(4f);
    }

    private void AnimateZombie()
    {
        Debug.Log($"Set {heal}");
        if (heal <= 40)
        {
            myAnimator.SetBool("Lv2", true);

        }
    }
}
