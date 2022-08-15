using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerAttack playerAttack;

    [SerializeField] private int m_damage;

    void Awake()
    {
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Goblin")
        {
            GoblinController goblinController = collider.GetComponent<GoblinController>();
            goblinController.TakeDamage(m_damage);
        }
    }
}
