using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        print("collided with particles");
        --health;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    public void DamageBase()
    {
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
