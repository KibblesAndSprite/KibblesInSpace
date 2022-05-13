using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _health = 50f;

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            // possiblity replace Destroy
            Destroy(gameObject);
        }
    }
}
