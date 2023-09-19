using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float rotateSpeed;

    [Header("Health")]
    public int health;
    public int maxHealth = 4;

    [Header("Shooting")]
    public float distanceToShoot = 20f;
    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool canShoot = true;

    [Header("Dying")]
    public GameObject explosion;

    Transform target;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTarget();
        }

        if (target)
        {
            if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
            {
                if (canShoot == true)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        // Debug.Log(Vector2.Distance(target.position, transform.position));
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void RotateTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, rotateSpeed);
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
