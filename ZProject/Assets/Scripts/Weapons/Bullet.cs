using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject hitEffectPrefab;

    public float Velocity { get; set; }


    void FixedUpdate()
    {
        transform.Translate(Velocity * transform.forward * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == GameManager.Instance.zombiesLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
