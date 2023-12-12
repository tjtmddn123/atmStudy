using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DepositManager : MonoBehaviour
{
    public Text bankBalanceText;        // ���� �ܾ� Text UI ���
    public Text cashText;               // ���� ���� Text UI ���
    public InputField inputField;       // �ݾ��� �Է¹��� InputField UI ���
    public GameObject noMyCashImage;    // ���� ������ ������ �� ������ �̹��� UI ���
    public GameObject pausePanel;       // �Ͻ� ���� �г�

    private MainSceneUIManager mainUIManager; // ���ξ��� UI �Ŵ���


    void Start()
    {
        mainUIManager = FindObjectOfType<MainSceneUIManager>(); // MainSceneUIManager�� ã��
        UpdateUI();  // ������ �� UI ������Ʈ
    }

    void UpdateUI()
    {
        bankBalanceText.text = "���� �ܾ�: " + mainUIManager.bankBalance.ToString() + "��"; 
        // ���� �ܾ� UI ������Ʈ
        cashText.text = "���� ����: " + mainUIManager.cash.ToString() + "��";              
        // ���� ���� UI ������Ʈ
    }

    public void TransferFromCashToBank()
    {
        int amount = int.Parse(inputField.text); 
        // �Էµ� �ݾ��� ������ ��ȯ

        if (mainUIManager.cash >= amount)
        {
            mainUIManager.Deposit(amount); 
            // ���ξ��� UI �Ŵ����� ���� �Ա� ��� ����
            UpdateUI();  // UI ������Ʈ

            noMyCashImage.SetActive(false);
            // ���� ���� ���� �̹��� ��Ȱ��ȭ

            ResumeGame();
        }
        else
        {
            PauseGame();
            noMyCashImage.SetActive(true); 
            // ���� ���� ���� �̹��� Ȱ��ȭ
        }
    }

    // �� ��ư�� ������ �� �ش� �ݾ��� ��ǲ �ʵ忡 �����ϴ� �Լ���
    public void SetAmount10000()
    {
        inputField.text = "10000";
    }

    public void SetAmount30000()
    {
        inputField.text = "30000";
    }

    public void SetAmount50000()
    {
        inputField.text = "50000";
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToGame()
    {
        ResumeGame(); // ���� �簳
        noMyCashImage.SetActive(false); // �г� ��Ȱ��ȭ
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ð��� ����
        pausePanel.SetActive(true); // �Ͻ� ���� �г� Ȱ��ȭ
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // ���� �ð��� �ٽ� ��
        pausePanel.SetActive(false); // �Ͻ� ���� �г� ��Ȱ��ȭ
    }
}

