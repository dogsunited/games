using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float MoveSpeed;
    public float Yforce;
    public float Mobile_JumpForce;
    public LayerMask whatIsGround;
    public float checkRadius;
    public Transform GroundPosition;
    public bool isGrounded;
    public GameObject GameOverCanvas;
    public AudioSource JumpSound;

    private float JumpTimeCounter;
    public float JumpTime;
    public bool IsJumping;

    [Header("Difficulty")]
    public float TimeBtwIncrease;
    public float StartTimeBtwIncrease;
    public float IncreaseAmount;
    public float MaxSpeed;
    [Header("Health")]
    public int Health;
    public GameObject Health_Display;
    public GameObject Health_Display2;
    public GameObject Health_Display3;

    public static float distancemeters;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
        

    // Update is called once per frame
    void Update()
    {
       
        if(Health <= 2)
        {
            Health_Display.SetActive(false);
        }
        else
        {
            Health_Display.SetActive(true);
        }
        if (Health <= 1)
        {
            Health_Display2.SetActive(false);
        }
        else
        {
            Health_Display2.SetActive(true);
        }

        if (Health <= 0)
        {
            Health_Display3.SetActive(false);
            distancemeters = DistacneCalculator.meters;
        }
        else
        {
            Health_Display3.SetActive(true);
        }
        isGrounded = Physics2D.OverlapCircle(GroundPosition.position, checkRadius, whatIsGround);

        
        rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                JumpSound.Play();
                IsJumping = true;
                JumpTimeCounter = JumpTime;
                rb.velocity = new Vector2(rb.velocity.x, Yforce);
            }
           
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) )
        {
            if (IsJumping)
            {
                if (JumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, Yforce);
                    JumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    IsJumping = false;
                }
            }
            
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }


        if (Health <= 0)
        {
            MoveSpeed = 0f;
            gameObject.SetActive(false);
            GameOverCanvas.SetActive(true);
        }
        
        if (!isGrounded)
        {
               animator.SetBool("Jump", true);

        }
        

        else if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }

        //Difficulty
        if(TimeBtwIncrease <= 0)
        {
            TimeBtwIncrease = StartTimeBtwIncrease;
            if(MoveSpeed < MaxSpeed)
            {
                MoveSpeed += IncreaseAmount;
            }
        }
        else
        {
            TimeBtwIncrease -= Time.deltaTime;
        }
    }

    public void Jump_Touch()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mobile_JumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Finish")
        {
            Health = 0;

            //StartCoroutine(GameOver());
        }

        if (collision.collider.tag == "Spike")
        {
            Health--;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Collected++;
            //GetComponent<AudioSource>().Play();
            //AmountText.text = Collected.ToString();
            //PlayerPrefs.SetInt("Collected", Collected) ;
            if (Health < 3)
            {
                Health = Health + 1;

            }
            Destroy(other.gameObject);
        }
    }
    /* IEnumerator GameOver()
     {
         yield return new WaitForSeconds(0.5f);
         gameObject.SetActive(false);
         GameOverCanvas.SetActive(true);
     }*/
}
