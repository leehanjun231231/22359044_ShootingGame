using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{

    public Material mBG;

    public float spd = 0.2f;



    // Update is called once per frame
    void Update()
    {

        Vector2 dir = Vector2.up;
        mBG.mainTextureOffset += dir * spd * Time.deltaTime;


    }
}
