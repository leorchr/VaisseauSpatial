using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    private Vector2 laserSize;
    private Vector2 screenSize;

    void Start()
    {
        laserSize = GetComponent<RectTransform>().sizeDelta;
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;
    }
    
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.localPosition.x >= screenSize.x / 2 + laserSize.x / 2)
        {
            Destroy(gameObject);
        }

        if (transform.localPosition.y >= screenSize.y / 2 + laserSize.y / 2)
        {
            Destroy(gameObject);
        }

        if (transform.localPosition.x < -screenSize.x / 2 - laserSize.x / 2)
        {
            Destroy(gameObject);
        }

        if (transform.localPosition.y < -screenSize.y / 2 - laserSize.y / 2)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
