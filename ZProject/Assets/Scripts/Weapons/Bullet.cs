using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;

    public float Velocity { get; set; }

    void FixedUpdate()
    {
        transform.Translate(Velocity * Vector3.forward * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Zombie zombie = collision.gameObject.GetComponent<Zombie>();
        if (zombie)
            Destroy(collision.gameObject);
        else
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
