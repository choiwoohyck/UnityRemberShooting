using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum EnemyType
{
    RUSH,
    SHOOT
}

public class Enemy
{
    
    EnemyType type;
    float hp;

    Enemy(EnemyType _type)
    {
        type = _type;
    }
}

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[5];
        
    float random_timer = 0; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        random_timer += Time.deltaTime;

        if (random_timer >= 10f)
            random_timer = 0;
    }
}
