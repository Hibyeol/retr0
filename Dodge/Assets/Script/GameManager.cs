using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameoverText; //���ӿ����� Ȱ��ȭ �� ���� ������Ʈ
    public Text timeText; // �����ð��� ǥ���� ������Ʈ
    public Text recordText; // �ְ����� ǥ���� ������Ʈ

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
            timeText.text = "Time :" + (int)surviveTime; // �ð� ǥ��
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge"); //Dodge �� �����
            }
        }
    }

    public void EndGame()
    {
        isGameover = true; // ���ӿ��� ���·� ��ȯ
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) // �ð��� �� ��ٸ� �ð� ����
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime; // �ְ� �÷��̽ð� ǥ��
    }
}
