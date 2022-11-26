using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Vector2 movDir = new Vector2();
    private Rigidbody2D rb2d;
    private Animator anim;
    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movDir.x = Input.GetAxisRaw("Horizontal");
        movDir.y = Input.GetAxisRaw("Vertical");
        movDir.Normalize();

        //transform.position += new Vector3(movDir.x,movDir.y,0.0f)*moveSpeed*Time.deltaTime;
        // transform.position = Vector2.MoveTowards(transform.position,target.position,Time.deltaTime*moveSpeed);
        //transform.Translate(movDir*moveSpeed*Time.deltaTime);
        //Debug.Log("XXXXXX"+movDir.ToString());
        //rb2d.AddForce(movDir);
        //rb2d.MovePosition(new Vector2(transform.position.x,transform.position.y)+ movDir * moveSpeed * Time.fixedDeltaTime);
        //rb2d.position += movDir * moveSpeed * Time.fixedDeltaTime;
        if (!(weapon.beCanWalk))
        {
            movDir.x = 0.0f;
            movDir.y = 0.0f;
        }

        rb2d.velocity = moveSpeed * movDir;
    }

    private void UpdateState()
    {
        if (Mathf.Approximately(movDir.x, 0.0f) && Mathf.Approximately(movDir.y, 0.0f))
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetFloat("xDir", movDir.x);
            anim.SetFloat("yDir", movDir.y);
            anim.SetBool("isWalking", true);
        }
    }
}
