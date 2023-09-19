using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    Vector2 moveDirection;
    Rigidbody2D rb;

    [Header("Rotate")]
    public bool facingRight;
    float pos_x,
        pos_y;
    float valueRotation;

    [Header("Sound")]
    public AudioSource soundFire;

    [Header("Shoot")]
    public ShottingScript shotting;

    public HealthManager _health;

    // Renderer ren;
    // public Color startColor;
    // public Color endColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // ren = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        pos_x = Input.GetAxisRaw("Horizontal");
        pos_y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            shotting.Fire();
            soundFire.Play();
        }

        if (ScoreManager.instance._score % 50 == 0)
        {
            if (_health.health < 4)
            {
                _health.health++;
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
        RotateTarget();
    }

    private void Movement()
    {
        moveDirection = new Vector2(pos_x, pos_y).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        rb.position = new Vector2(
            Mathf.Clamp(transform.position.x, -36.0f, 36.0f),
            Mathf.Clamp(transform.position.y, -20.0f, 20.0f)
        );
    }

    private void RotateTarget()
    {
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

    public void TakeDamage()
    {
        _health.health--;
        if (_health.health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            StartCoroutine(Hurt());
        }
    }

    IEnumerator Hurt()
    {
        // ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * 2.0f, 1.0f));
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(6, 9);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }
}
