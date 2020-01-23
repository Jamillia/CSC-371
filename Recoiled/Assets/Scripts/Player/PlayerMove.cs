using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float speed_limit = 5.0f;

    public bool isFacingRight;
    public float jumpForce = 5.0f;
    private Rigidbody2D rb;
    public bool canMove = true;
    public bool canJump = true;
    public float recoilForce;
    float AirRecoilForce;
    float GroundrecoilForce;
    public bool did_shot = false;
    public float sqrt;
    public float distancePt;

    public bool isGround;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
        AirRecoilForce = recoilForce;
        GroundrecoilForce = recoilForce / 2.5f;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("SampleScene"); //Load scene called Game
        }

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) && rb.velocity.x >= -speed_limit)
            {
                rb.velocity += new Vector2(transform.right.x, 0) * -speed;
                if (isFacingRight)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    isFacingRight = false;
                }
            }
            if (Input.GetKey(KeyCode.D) && rb.velocity.x <= speed_limit)
            {
                rb.velocity += new Vector2(transform.right.x, 0) * speed;
                if (!isFacingRight)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    isFacingRight = true;
                }
            }

            if (Input.GetKeyDown("space") && isGround)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumpTimeCounter = jumpTime;
                isJumping = true;
            }
            if (Input.GetKey("space") && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.AddForce(Vector2.up * jumpForce / 5f);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp("space"))
            {
                isJumping = false;
            }

            //Code for Recoil Boost
            if (did_shot)
            {
                distancePt = distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
                rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * -(recoilForce * 100) / Mathf.Sqrt(distancePt));
                did_shot = false;
            }
        }
        
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

    }

    public float distance(Vector2 a, Vector2 b)
    {
        sqrt = (Mathf.Pow(a.x - b.x, 2)
            + Mathf.Pow(a.y - b.y, 2));
        return Mathf.Sqrt(sqrt);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Ledge")
        {
            canJump = true;
            recoilForce = GroundrecoilForce;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Ledge")
        {
            recoilForce = AirRecoilForce;
        }
    }
    
}
