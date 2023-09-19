using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemies : MonoBehaviour
{
    float fireForce;

    private void Update() { }

    private void FixedUpdate()
    {
        if (ScoreManager.instance._score < 19)
        {
            fireForce = Random.Range(8, 10);
        }
        else if (ScoreManager.instance._score > 19 && ScoreManager.instance._score < 59)
        {
            fireForce = Random.Range(10, 13);
        }
        else
        {
            fireForce = Random.Range(13, 15);
        }
        
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
        PlayerController playerController = other.GetComponent<PlayerController>();
        playerController.TakeDamage();
        Destroy(this.gameObject);
    }
}
