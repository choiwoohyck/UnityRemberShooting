using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    float shootDelay = 0.2f;
    float shootTimer =0 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) //쿨타임이 지났는지와, 공격키인 스페이스가 눌려있는지 검사합니다.
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); //레이저를 생성해줍니다.
            shootTimer = 0; //쿨타임을 다시 카운트 합니다.
        }
        shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
    }
}
