using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float currentAmmo;
    public float maxAmmo;
    public Animator anim;
    public Camera myCam;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Fire());
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }

    public IEnumerator Fire()
    {
        muzzleFlash.Play();
        //triggers a muzzle flash once
        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, 100f))
        {
            Debug.Log(hit.transform.name);
            hit.transform.gameObject.SendMessageUpwards("TakeDamage", 10);
            //accesses the TakeDamage function of the hit object without needing to check 
            hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * 5, ForceMode.Impulse);
            //add force 
        }
        Debug.Log("Pew");
        anim.SetBool("Fire", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Fire", false);
    }
}
