using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//탄알 복제 생성

public class BulletSpanwer : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 원본 
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; // 발사할 대상 
    private float spanwRate; //생성주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간
    
    void Start()
    {
        timeAfterSpawn = 0f; // 누적 시간 초기화

        spanwRate = Random.Range(spawnRateMin, spawnRateMax); // 생성 간격 재정

        target = FindObjectOfType<PlayerController>().transform; // 조준 대상 설정
    }

    // Update is called once per frame
    void Update() 
    {
        timeAfterSpawn += Time.deltaTime;// 갱신

        if (timeAfterSpawn >= spanwRate) // 누적된 시간이 생성주기와 같거나 크다면
        {
            timeAfterSpawn = 0f; //리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);//

            bullet.transform.LookAt(target);

            spanwRate = Random.Range(spawnRateMin, spawnRateMax);
        }
         
    }
}
