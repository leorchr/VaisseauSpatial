using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    public GameObject laser;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public Transform parent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laser, spawnPoint.transform.position, spawnPoint.transform.rotation, parent);
            Instantiate(laser, spawnPoint2.transform.position, spawnPoint2.transform.rotation, parent);
        }
    }
}
