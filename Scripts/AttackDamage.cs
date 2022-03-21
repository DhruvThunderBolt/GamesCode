using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 50f;
    
    void Start() 
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);

        if(hits.Length > 0)
        {
            hits[0].GetComponent<HealthScript>().applyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
