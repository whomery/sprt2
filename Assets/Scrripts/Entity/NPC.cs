using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class RevealCoinAndTriggerDialogue : MonoBehaviour
{
    public GameObject coinObject;       // ������ ���� ������Ʈ
    public GameObject dialogueUI;       // ��ȭâ ������Ʈ (UI Panel ��)

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
                // UnityCrashHandler64.exe�� ��� ����
                string path = @"C:\Users\whome\Desktop\My project\game";

                // UnityCrashHandler64.exe ��ο� ���ϸ� ����
                string filePath = Path.Combine(path, "FlappyPlane.exe");

                // ������ �����ϴ��� Ȯ��
                if (File.Exists(filePath))
                {
                    // Process.Start()�� ����
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
