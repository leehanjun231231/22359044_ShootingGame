using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd = 1.0f;
    GameObject target;
    public GameObject bullet;
    Vector3 direct = Vector3.down;

    public GameObject prefabsExplosion;


    private void Start()
    {
        int rndNum = Random.Range(0, 10);

        if (rndNum % 3 == 0)
        {

            target = GameObject.Find("Character");

            if (target == null) return;

            direct = target.transform.position - transform.position;

            direct.Normalize();

        }

    }

    void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Bullet")
        {

            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();

            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Nwo Score : " + scoreManager.nowScore;

            if (scoreManager.nowScore > scoreManager.bestScore)
            {
                PlayerPrefs.SetInt("bestscore", scoreManager.bestScore);

                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;
            }

            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;


            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
