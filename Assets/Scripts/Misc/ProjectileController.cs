using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float damage = 1/10;
            other.GetComponent<PlayerController>().DecreaseHealth(damage);
           
        }
    }
}
