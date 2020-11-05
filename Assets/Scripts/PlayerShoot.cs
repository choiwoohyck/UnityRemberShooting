using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    float shootDelay = 0.2f;
    float shootTimer =0;
    // Start is called before the first frame update

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        shootDelay = gameObject.GetComponent<PlayerState>().shootDelay;
            
        if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) 
        {
            ObjectPool.GetObject(GameObject.Find("Player").transform.position,gameObject.GetComponent<PlayerState>().damage);
            shootTimer = 0; 
        }

        shootTimer += Time.deltaTime; 
    }
}
