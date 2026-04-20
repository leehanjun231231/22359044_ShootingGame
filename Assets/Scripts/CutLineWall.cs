using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLineWall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.tag == "Player")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameOverManager>().ShowGameOver();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }


    }

}
