using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    private void OnEnable()
    {
        shootTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().TakeDamage(damage);
        else if (other.CompareTag("Enemy"))
            other.GetComponent<Player>().TakeDamage(damage);

        gameObject.SetActive(false);
    }
}
