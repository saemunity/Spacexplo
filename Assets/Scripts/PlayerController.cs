using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool facingRight;
    public AudioSource soundFire;

    // public float rotation = 30f;

    float valueRotation;
    Vector2 moveDirection;
    Rigidbody2D rb;

    Vector3 rotation;

    public ShottingScript shotting;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotting.Fire();
            soundFire.Play();
        }
    }

    private void FixedUpdate()
    {
        float pos_x = Input.GetAxisRaw("Horizontal");
        float pos_y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(pos_x, pos_y).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        rb.position = new Vector2(
            Mathf.Clamp(transform.position.x, -36.0f, 36.0f),
            Mathf.Clamp(transform.position.y, -20.0f, 20.0f)
        );

        valueRotation = transform.rotation.eulerAngles.z;

        if (pos_x > 0)
        {
            facingRight = true;
            if (valueRotation == 0 && facingRight == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 20);
            }
        }
        else if (pos_x < 0)
        {
            facingRight = false;
            if (valueRotation == 0 && facingRight == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 340);
            }
        }
        else if (pos_x == 0)
        {
            if (valueRotation != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
