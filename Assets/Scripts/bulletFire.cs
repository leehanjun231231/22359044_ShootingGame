using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFire : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletFireObject;

    public int maxBullet = 10;
    private int currentBullet;
    public float reloadTime = 2.0f;
    private float reloadTimer = 0.0f;
    private bool isReloading = false;

    void Start()
    {
        currentBullet = maxBullet;
    }

    private void Update()
    {

        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                currentBullet = maxBullet;
                isReloading = false;
                reloadTimer = 0.0f;
            }
        }

        if (Input.GetButtonDown("Jump") && currentBullet > 0)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.transform.position = bulletFireObject.transform.position;
            currentBullet--;
        }

        if (currentBullet <= 0)
        {
            isReloading = true;
        }

    }


}
