using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ź�� ���� ����

public class BulletSpanwer : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ���� 
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; // �߻��� ��� 
    private float spanwRate; //�����ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    
    void Start()
    {
        timeAfterSpawn = 0f; // ���� �ð� �ʱ�ȭ

        spanwRate = Random.Range(spawnRateMin, spawnRateMax); // ���� ���� ����

        target = FindObjectOfType<PlayerController>().transform; // ���� ��� ����
    }

    // Update is called once per frame
    void Update() 
    {
        timeAfterSpawn += Time.deltaTime;// ����

        if (timeAfterSpawn >= spanwRate) // ������ �ð��� �����ֱ�� ���ų� ũ�ٸ�
        {
            timeAfterSpawn = 0f; //����

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);//

            bullet.transform.LookAt(target);

            spanwRate = Random.Range(spawnRateMin, spawnRateMax);
        }
         
    }
}
