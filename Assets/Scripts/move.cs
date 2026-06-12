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

        Vector3 direct = new Vector3(h, v, 0);
        Vector3 pos = transform.position + direct * spd * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -2f, 2f);

        transform.position = pos;
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