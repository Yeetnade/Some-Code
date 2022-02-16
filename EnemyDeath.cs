using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 5f;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }
    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

 
}
