using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class move : MonoBehaviour
{

    public float spd = 5f;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 direct = Vector3.right * h + Vector3.up * v;

        //transform.Translate(direct * spd * Time.deltaTime);

        Vector3 direct = new Vector3(h, v, 0);
        transform.position = transform.position + direct * spd * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Monster")
        {

            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameOverManager>().ShowGameOver();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

}
