using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void FixedUpdate()
    {
        rb.position = new Vector2(
            Mathf.Clamp(transform.position.x, -40f, 40f),
            Mathf.Clamp(transform.position.y, -40f, 40f)
        );

        if (
            transform.position.x < -39f
            || transform.position.x > 39f
            || transform.position.y > 39f
            || transform.position.y < -39f
        )
        {
            Destroy(gameObject);
        }
    }
}
