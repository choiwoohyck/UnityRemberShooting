using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 3;
    public int damage = 1;
    public float speed = 10f;
    public float shootDelay = 0.2f;
    public bool isInvincible = false;
    private bool isDead = false;
    

    
    private void StateInit()
    {
        hp = 3;
        damage = 1;
        speed = 10f;
        shootDelay = 0.2f;
        isDead = false;
        isInvincible = false;
    }

    void Start()
    {
        StateInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
            isDead = true;

        if (isInvincible)
        {
            StartCoroutine(Invincible());
            isInvincible = false;
        }
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(1);
    }
}
