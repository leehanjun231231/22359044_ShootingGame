using UnityEngine;
using UnityEngine.UI;

public class bulletFire : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletFireObject;

    public AudioSource Reload_Audio;
    public AudioSource ReloadMan_Audio;
    public int maxBullet = 10;
    private int currentBullet;
    public float reloadTime = 2.0f;
    private float reloadTimer = 0.0f;
    private bool isReloading = false;
    public float sliderPos = 10f;

    public Slider reloadSlider;

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
                Reload_Audio.Stop();
                UpdateBulletSlider();
            }
        }

        if (Input.GetButtonDown("Jump") && currentBullet > 0)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.transform.position = bulletFireObject.transform.position;
            currentBullet--;

            UpdateBulletSlider();
        }

        if (currentBullet <= 0 && !isReloading)
        {
            Reload_Audio.Play();
            ReloadMan_Audio.Play();
            isReloading = true;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(bulletFireObject.transform.position);
        reloadSlider.transform.position = screenPos + new Vector3(5, sliderPos, 0);
    }


    void UpdateBulletSlider()
    {
        if (reloadSlider != null)
        {
            reloadSlider.value = (float)currentBullet / (float)maxBullet;
        }
    }

}
