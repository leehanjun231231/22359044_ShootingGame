using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float spd = 3.5f;

    private void Update()
    {
        transform.Translate(Vector3.up * spd * Time.deltaTime);
    }


}
