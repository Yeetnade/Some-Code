using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject playerBullet;

    public float bulletForce = 20f;

    public int bulletCount;
    public GameObject AmmoMask;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public Text ammoDisplay;

    // Update is called once per frame

    void Update()
    {
        ammoDisplay.text = bulletCount.ToString();
        if (Input.GetButton("Fire1") && bulletCount > 0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

        }

        if (Input.GetKeyDown(KeyCode.R) && bulletCount < 1)
        {
            bulletCount = 30;
            AmmoMask.GetComponent<MaskScript>().MoveMask(bulletCount, 30);
        }

        void Shoot()
        {
            GameObject bullet = Instantiate(playerBullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bulletCount--;
            AmmoMask.GetComponent<MaskScript>().MoveMask(bulletCount, 30);


        }
        
    }
}
