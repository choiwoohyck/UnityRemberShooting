using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMover : MonoBehaviour
{
    GameObject[] buildings = new GameObject[8];
    float[] speed = new float[8];
    // Start is called before the first frame update
    void Start()
    {
          
        for (int i = 0; i < 8; i++)
        {
            buildings[i] = transform.GetChild(i).gameObject;
        }

        speed[0] = speed[4] = 7;
        speed[1] = speed[5] = 6;
        speed[2] = speed[6] = 5;
        speed[3] = speed[7] = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
       for (int i = 0; i < 8; i++)
       {
            buildings[i].transform.position = new Vector2(buildings[i].transform.position.x - Time.deltaTime * speed[i], buildings[i].transform.position.y);
            if (buildings[i].transform.position.x < -10.8)
                buildings[i].transform.position = new Vector2(10.8f, buildings[i].transform.position.y);

        }
    }
}
