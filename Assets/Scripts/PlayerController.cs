using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laserPrefab; 
    public Transform firePoint;    
    public float fireRate = 0.5f;  // Seri atışlar arası süre
    private float nextFire = 0f;   // Bir sonraki atış zamanı

    void Update()
    {
        // Space tuşuna basılı tutulduğunda ve bekleme süresi dolduğunda ateş et
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            FireLaser();
        }
    }

    void FireLaser()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}
