using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingScript : MonoBehaviour
{
    Camera mainCamera;
    Vector3 mousePos;
    public BulletScript bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        Debug.Log("mousePos: " + mousePos);
        Debug.Log("rotation: " + rotation);
        Debug.Log("rotZ: " + rotZ);
        Debug.Log("transform.rotation: " + transform.rotation);
    }

    public void Fire()
    {
        BulletScript projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
