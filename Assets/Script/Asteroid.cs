using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    private Vector2 shipSize;
    private Vector2 screenSize;
    public float angle;
    public GameObject AsteroidPrefab;
    public Transform parent;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        shipSize = GetComponent<RectTransform>().sizeDelta;
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;
        parent = FindObjectOfType<Canvas>().GetComponent<Transform>();
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.localPosition.x >= screenSize.x / 2 + shipSize.x / 2)
        {
            transform.localPosition = new Vector3(-screenSize.x / 2 - shipSize.x / 2, transform.localPosition.y, 0);
        }

        if (transform.localPosition.y >= screenSize.y / 2 + shipSize.y / 2)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -screenSize.y / 2 - shipSize.y / 2, 0);
        }

        if (transform.localPosition.x < -screenSize.x / 2 - shipSize.x / 2)
        {
            transform.localPosition = new Vector3(screenSize.x / 2 + shipSize.x / 2, transform.localPosition.y, 0);
        }

        if (transform.localPosition.y < -screenSize.y / 2 - shipSize.y / 2)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, screenSize.y / 2 + shipSize.y / 2, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(AsteroidPrefab, transform.position, Quaternion.identity, parent);
        Destroy(gameObject);
    }
}