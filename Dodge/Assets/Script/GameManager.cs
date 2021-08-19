using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameoverText; //게임오버시 활성화 될 게임 오브젝트
    public Text timeText; // 생존시간을 표시할 컴포넌트
    public Text recordText; // 최고기록을 표시할 컴포넌트

    private float surviveTime;
    private bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time :" + (int)surviveTime; // 시간 표시
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge"); //Dodge 씬 재시작
            }
        }
    }

    public void EndGame()
    {
        isGameover = true; // 게임오버 상태로 변환
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) // 시간이 더 길다면 시간 갱신
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime; // 최고 플레이시간 표사
    }
}
