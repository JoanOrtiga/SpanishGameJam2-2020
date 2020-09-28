using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Collisions coll;
    Animator anim;

    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpforce = 10;
    [SerializeField] private float timeUntilWallJump = 1.5f;
    

    private bool canMove = true;
    private bool canWallJump = true;
    public bool dashing = false;

    [HideInInspector] public bool extraJump = false;
    public float dashSpeed = 20;

    private float gravityScale;
    [HideInInspector] public bool jumpedOfGround = false;

    public ParticleSystem runningRight;
    public ParticleSystem runningLeft;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collisions>();
        anim = GetComponent<Animator>();

        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (coll.onGround || extraJump)
            {
                jumpedOfGround = true;

                if (extraJump)
                {
                    extraJump = false;
                }
                else
                {
                    anim.SetFloat("VerticalSpeed", rb.velocity.y);
                    anim.SetTrigger("Jump");
                }
  
                Jump(Vector2.up);
            }
               
            else if (coll.onWall && canWallJump)
            {
                WallJump();
                jumpedOfGround = true;
            }
        }

        if (coll.onGround)
        {
            StopCoroutine(DisableWallJump(0));
            canWallJump = true;
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1, 1);

            if (coll.onGround && rb.velocity.y == 0)
            {
                runningRight.Clear();

                runningLeft.enableEmission = true;
                runningRight.enableEmission = false;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(1, 1);

            if (coll.onGround && rb.velocity.y == 0)
            {
                runningLeft.Clear();

                runningLeft.enableEmission = false;
                runningRight.enableEmission = true;
            }
        }

        if(rb.velocity.y != 0 || !coll.onGround || Input.GetAxis("Horizontal") == 0)
        {
            if (rb.velocity.y != 0 || !coll.onGround)
            {
                runningLeft.Clear();
                runningRight.Clear();
            }
            runningLeft.enableEmission = false;
            runningRight.enableEmission = false;
        }

        anim.SetBool("OnWall", coll.onWall);
        anim.SetFloat("VerticalSpeed", rb.velocity.y);
    }

    private void Walk(Vector2 dir)
    { 
        if (!canMove || dashing /*|| coll.onWall*/)
            return;

        anim.SetFloat("InputX", dir.x);


        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));

    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = dir * jumpforce;
    }
    private void WallJump()
    {
        //StartCoroutine(DisableWallJump(timeUntilWallJump));


        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1.2f + wallDir / 1.5f));
    }

    IEnumerator DisableWallJump(float time)
    {
        canWallJump = false;
        yield return new WaitForSeconds(time);
        canWallJump = true;
    }

    public void Dash(float x, float y)
    {
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x,y);

        print(dir + " " + dir * dashSpeed);

        rb.velocity = dir * dashSpeed;

        StartCoroutine(DashWait());

    }

    IEnumerator DashWait()
    {
        GetComponent<BetterJump>().enabled = false;
        rb.gravityScale = 0;
        dashing = true;

        yield return new WaitForSeconds(.3f);

        dashing = false;
        GetComponent<BetterJump>().enabled = true;
        rb.gravityScale = gravityScale;
    }

}
