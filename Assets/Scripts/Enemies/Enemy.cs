using RPGCharacterAnims.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Stats
    [SerializeField] float health, damage;
    #endregion
    public GameObject thisEnemy;
    public Animator thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //CollectRagdolls();
        //RagdollOff();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Death();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }
    public void Death()
    {
        thisEnemy.GetComponent<Animator>().enabled = false; 
        //now, in theory, this should disable the animator and turn the enemy into a rigidbody they can 

    }
    public void TakeDamage(float healthDamage)
    {
        health -= healthDamage;
    }
    Collider[] ragDollColliders;
    Rigidbody[] limbBodies;
}
