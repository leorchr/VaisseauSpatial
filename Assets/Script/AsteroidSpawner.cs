using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform spawnParent;
    public GameObject AsteroidPrefab;
    public int nbAsteroid;
    private Vector2 screenSize;


    void Start()
    {
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;
        for (int i = 0; i < nbAsteroid; i++)
        {
            float x = Random.Range(0, screenSize.x);
            float y = Random.Range(0, screenSize.y);
            GameObject spawn = Instantiate(AsteroidPrefab, spawnParent);
            spawn.transform.position = new Vector2(x,y);
        }
    }
}
