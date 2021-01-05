using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    public int damages = 0;

    public float Velocity { get; set; }

    void FixedUpdate()
    {
        transform.Translate(Velocity * Vector3.forward * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Zombie zombie = collision.gameObject.GetComponent<Zombie>();
        if (zombie)
        {
            zombie.TakeHit(damages);
        }
        else
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
