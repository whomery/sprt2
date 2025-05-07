using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class RevealCoinAndTriggerDialogue : MonoBehaviour
{
    public GameObject coinObject;       // 숨겨진 코인 오브젝트
    public GameObject dialogueUI;       // 대화창 오브젝트 (UI Panel 등)

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (coinObject != null)
            coinObject.SetActive(false);

        if (dialogueUI != null)
            dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (dialogueUI != null)
            {
                // UnityCrashHandler64.exe의 경로 설정
                string path = @"C:\Users\whome\Desktop\My project\game";

                // UnityCrashHandler64.exe 경로와 파일명 결합
                string filePath = Path.Combine(path, "FlappyPlane.exe");

                // 파일이 존재하는지 확인
                if (File.Exists(filePath))
                {
                    // Process.Start()로 실행
                    Process.Start(filePath);
                }
                else
                {
                    
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (coinObject != null)
                coinObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (coinObject != null)
                coinObject.SetActive(false);

            if (dialogueUI != null)
                dialogueUI.SetActive(false);
        }
    }
}
