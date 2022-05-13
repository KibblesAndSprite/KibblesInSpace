using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _damage = 10f;


    //Currentl just moves prefab to the right. will update later
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();

        health.DealDamage(_damage);
        
    }
}
