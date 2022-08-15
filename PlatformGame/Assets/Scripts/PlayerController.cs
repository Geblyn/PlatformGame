using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_rb2d;
    private Animator m_Animator;
    [SerializeField] private GameObject player;
    private PlayerAttack playerAttack;

    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpPower;
    
    private float m_horizontalMove;
    private float m_verticalMove;
    private float m_Velocity;
    
    private bool m_isAttacking;
    public bool m_isJumping;
    public bool m_isMoving;
    private bool m_facingRight;

    // Event begin play
    void Start()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        playerAttack = player.GetComponent<PlayerAttack>();
        
        m_isJumping = false;
        m_facingRight = true;
    }

    // Event tick
    void Update()
    {
        //assigns the variables to either 1 -1 or 0 depending on if a or d is being pressed or not
        m_horizontalMove = Input.GetAxisRaw("Horizontal");
        m_verticalMove = Input.GetAxisRaw("Vertical");

        m_isAttacking = playerAttack.isAttacking;


    }

    //Event tick but with physics engine
    void FixedUpdate()
    {
        m_Velocity = m_rb2d.velocity.y;
        m_Animator.SetFloat("Speed", Mathf.Abs(m_horizontalMove));
        m_Animator.SetBool("isJump", m_isJumping);
        m_Animator.SetFloat("Velocity", m_Velocity);

        if(m_horizontalMove > 0f || m_horizontalMove < 0f)
        {
            if(!m_isAttacking)
            {   
                m_rb2d.AddForce(new Vector2(m_moveSpeed * m_horizontalMove, 0f), ForceMode2D.Impulse);
                m_isMoving = true;
            }
        }
        else
        {
            m_isMoving = false;
        }

        if(!m_isJumping && m_verticalMove > 0f)
        {
            m_rb2d.AddForce(new Vector2(0f, m_jumpPower * m_verticalMove), ForceMode2D.Impulse);
        }

        if(m_horizontalMove > 0 && !m_facingRight)
        {
            FlipChar();
        }

        if(m_horizontalMove < 0 && m_facingRight)
        {
            FlipChar();
        }

        if(!m_isMoving && !m_isJumping)
        {
            m_rb2d.velocity = new Vector2(0f, m_rb2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            m_isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            m_isJumping = true; 
        }
    }

    void FlipChar()
    {
        m_facingRight = !m_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
