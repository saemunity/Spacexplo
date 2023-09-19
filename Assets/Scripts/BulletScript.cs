using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damageAttack = 1;
    public float fireForce;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void FixedUpdate()
    {
        this.transform.position += this.transform.right * this.fireForce * Time.deltaTime;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemyController = other.GetComponent<EnemyController>();
        enemyController.TakeDamage(damageAttack);
        Destroy(this.gameObject);
    }
}
