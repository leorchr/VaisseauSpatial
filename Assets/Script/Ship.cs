using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Ship : MonoBehaviour
{
    public float speed;
    public float acceleration;
    private Vector2 shipSize;
    private Vector2 screenSize;
    public TextMeshProUGUI infoText;
    public float angle;
    public GameObject laser;
    public Transform parent;
    public Transform parent2;

    void Start()
    {
        shipSize = GetComponent<RectTransform>().sizeDelta;
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;
    }

    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector3 screenPoint = transform.position;
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


        if (Input.GetKey(KeyCode.Space) && speed <= 500)
        {
            speed += acceleration*Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.Space) && speed > 201)
        {
            speed -= acceleration * Time.deltaTime;
        }

        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.localPosition.x >= screenSize.x/ 2 + shipSize.x/2)
        {
            transform.localPosition = new Vector3(-screenSize.x/2 - shipSize.x/2, transform.localPosition.y, 0);
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

        infoText.text = string.Format("{0:00}:{1:00}", Time.timeSinceLevelLoad / 60, Time.timeSinceLevelLoad % 60);
        infoText.text += $"\nAcceleration :  {acceleration} ; Speed :  {(int)speed}";
    }
}