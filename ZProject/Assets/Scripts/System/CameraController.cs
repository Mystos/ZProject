using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float rotSpeed = 20f;

    private Vector3 cameraOffset;

    [Range(0.01f, 1f)]
    public float smoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    private void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = player.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (LookAtPlayer)
        {
            transform.LookAt(player.transform);
        }

    }
}
