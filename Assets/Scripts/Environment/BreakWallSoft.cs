using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallSoft : MonoBehaviour
{
    public float health;
    public Joint joint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(joint);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
