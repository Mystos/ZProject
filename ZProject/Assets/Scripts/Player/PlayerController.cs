using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Character Requierment")]
    CharacterController controller;
    public Camera cam;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public float offset = 2f;
    [Header("Character Metrics")]
    public float walkSpeed = 3;
    public float runSpeed = 6;
    [Header("Character Stats")]
    public PlayerStats stats;



    private Rigidbody body;
    private float speed;
    float turnSmooth;
    private Vector3 mousePos;




    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        // Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        // Mouse Orientation
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        // Move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movDir = new Vector3(horizontal, 0, vertical);
        controller.Move(movDir.normalized * speed * Time.deltaTime);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * -Mathf.Rad2Deg + -90f;
    }
}
