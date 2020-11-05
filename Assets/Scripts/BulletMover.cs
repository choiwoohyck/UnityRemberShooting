using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    float speed = 15;
    public int damage = 1;
    public GameObject effectPrefab;
 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Instantiate(effectPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            ObjectPool.ReturnObject(this);

            Debug.Log('d');
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyState>().hp -= damage;
            collision.gameObject.GetComponent<EnemyState>().colorCourinte = true; 
            ObjectPool.ReturnObject(this);

        }

    }
}
