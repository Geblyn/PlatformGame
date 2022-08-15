using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    
    [SerializeField] private int gobHealth;
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private GameObject PlayerSensor;
    [SerializeField] private GameObject EnemySensor;
    private Animator animator;
    private AiSensor playerSensor;
    private AiSensor enemySensor;
    private Rigidbody2D rb;
    
    private bool isHit;
    private float velocity;
    private bool playerDetected;
    private bool enemyDetected;
    [SerializeField] private bool facingRight;
    private Transform player;
    private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerSensor = PlayerSensor.GetComponent<AiSensor>();
        enemySensor = EnemySensor.GetComponent<AiSensor>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity.x;
        
        animator.SetBool("isHit", isHit);
        animator.SetInteger("Health", gobHealth);
        animator.SetFloat("velocity", Mathf.Abs(movement.x));
        
        playerDetected = playerSensor.playerDetected;
        enemyDetected = enemySensor.enemyDetected;
        player = playerSensor.Player;

        if(gobHealth <= 0)
        {
            StartCoroutine(Death());
        }

        if(!playerDetected)
        {
            movement = new Vector2(0f, 0f);
            rb.velocity = new Vector2(0f, 0f);
        }

        if(enemyDetected)
        {
            Debug.Log("Enemy detected");
            rb.velocity = new Vector2(0f, 0f);
        }

    }

    void FixedUpdate()
    {
        if(playerDetected)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement.x = direction.x;
            moveEnemy(movement);

            if(rb.velocity.x <= 0f && facingRight)
            {
                FlipChar();
            }
        
            if(rb.velocity.x > 0f && !facingRight)
            {
                FlipChar();
            }

        }
    }

    private void moveEnemy(Vector2 direction)
    {
        rb.AddForce(new Vector2(direction.x * moveSpeed, 0f), ForceMode2D.Impulse);
    }

    public void TakeDamage(int damage )
    {
        gobHealth = gobHealth - damage;
        StartCoroutine(Hit());
        
    }

    private IEnumerator Hit()
    {
        isHit = true;
        yield return new WaitForSeconds(.2f);
        isHit = false;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        
    }

    void FlipChar()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


}
