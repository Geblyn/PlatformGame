using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea;
    [SerializeField] GameObject player;
    PlayerController playerController;
    private Animator m_Animator;
    
    private bool isMoving;
    private bool isJumping;
    public bool isAttacking;

    private float attackTime = 0.30f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Awake()
    {
        attackArea = transform.GetChild(0).gameObject;
        m_Animator = gameObject.GetComponent<Animator>();

        playerController = player.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = playerController.m_isMoving;
        isJumping = playerController.m_isJumping;
        
        if(Input.GetMouseButtonDown(0))
        {
            if(!isJumping)
            {
                Attack();
            }
        }

        if(isAttacking)
        {
            timer += Time.deltaTime;

            if(timer >= attackTime)
            {
                timer = 0;
                isAttacking = false;
                attackArea.SetActive(isAttacking);
            }
        }
    }

    void FixedUpdate()
    {
        m_Animator.SetBool("isAttacking", isAttacking);
    }

    void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
