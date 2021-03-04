using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
        if (enemy)
        {
            enemy.DamageBase();
            FindObjectOfType<GameSession>().DecreaseHealth();
        }
    }
}
