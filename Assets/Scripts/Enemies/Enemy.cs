using RPGCharacterAnims.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Stats
    [SerializeField] float health, damage;
    #endregion
    #region Ragdoll On/Off
    public BoxCollider thisBoxCollider;
    public GameObject thisEnemy;
    public Animator thisAnimator;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        CollectRagdolls();
        RagdollOff();
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
        RagdollOn();
        //now, in theory, this should disable the animator and turn the enemy into a rigidbody they can 

    }
    public void TakeDamage(float healthDamage)
    {
        health -= healthDamage;
    }
    //[SerializeField] Collider[] ragDollColliders;
    // Rigidbody[] limbBodies;
   [SerializeField] List<Collider> ragDollColliders = new List<Collider>();
    [SerializeField]List<Rigidbody> limbBodies = new List<Rigidbody>();
    public void CollectRagdolls()
    {
        GetComponentsInChildren(ragDollColliders);
        GetComponentsInChildren(limbBodies);
        ragDollColliders.RemoveAt(0);
        limbBodies.RemoveAt(0);
    }
    public void RagdollOff()
    {
        foreach(Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach(Rigidbody rigid in limbBodies)
        {
            rigid.isKinematic = true;
        }
        thisBoxCollider.enabled = true;
        thisAnimator.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    public void RagdollOn()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbBodies)
        {
            rigid.isKinematic = false;
        }
        Destroy(thisBoxCollider);
        thisAnimator.enabled = false;
        //this.gameObject.tag = ("Grabbable");
        UnityEngine.Object.Destroy(this.gameObject.GetComponent<Rigidbody>());

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Grabbable" || collision.gameObject.tag == "WreckingBall")
        {
            Death();
        }
    }

}
