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
        bulletRigidbody = GetComponent <Rigidbody>();// 게임 오브잭트에서 컴포넌트를 찾아 할당
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f); // 3초뒤 파괴
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // 트리거 충돌 시 자동 실행
    {
        if(other.tag == "Player")  
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //상대방 컴포넌트 가져오기
 
            if (playerController != null) // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            {
                playerController.Die(); 
            }
        }
    }
}
