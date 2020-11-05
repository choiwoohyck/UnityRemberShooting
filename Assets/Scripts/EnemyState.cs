using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int hp = 5;
    public float speed = 0f;
    public bool isDead = false;
    public bool colorCourinte = false;
    public GameObject effectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void StateInit()
    {
        hp = 5;
        speed = 0f;

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            Instantiate(effectPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);   
        }          

        if (colorCourinte)
        {           
            StartCoroutine(ColorChange(Color.red));
            colorCourinte = false;
        }
    }


    public IEnumerator ColorChange(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;  
        yield return new WaitForSeconds(0.1f);      
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
