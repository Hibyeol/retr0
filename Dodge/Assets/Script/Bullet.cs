using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent <Rigidbody>();// ���� ������Ʈ���� ������Ʈ�� ã�� �Ҵ�
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f); // 3�ʵ� �ı�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // Ʈ���� �浹 �� �ڵ� ����
    {
        if(other.tag == "Player")  
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //���� ������Ʈ ��������
 
            if (playerController != null) // �������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            {
                playerController.Die(); 
            }
        }
    }
}
