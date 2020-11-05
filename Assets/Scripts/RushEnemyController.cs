using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemyController : MonoBehaviour
{
    public GameObject effectPrefab;

    float acceleration = 0;
    float speed;
    float angle;
    float x, y, z = 0;
    Vector2 targetPos;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<EnemyState>().speed;
        targetPos = GameObject.Find("Player").transform.position;

        x = transform.position.x;
        y = transform.position.y;

        angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
       
        x += Mathf.Cos(angle) * Time.deltaTime * speed;
        y += Mathf.Sin(angle) * Time.deltaTime * speed;

        transform.position = new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<PlayerState>().hp -= 1;
            collision.gameObject.GetComponent<PlayerState>().isInvincible = true;
            Instantiate(effectPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
