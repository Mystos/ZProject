using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject hitEffectPrefab;

    public float Velocity { get; set; }

    void FixedUpdate()
    {
        transform.Translate(Velocity * transform.forward * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == GameManager.Instance.zombiesLayer)
        {
            Destroy(collision.gameObject);
        }

        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
