using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFire : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletFireObject;

    private void Update()
    {
        bool isFire = Input.GetButtonDown("Jump");
        if (isFire)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.transform.position = bulletFireObject.transform.position;
        }
    }


}
