using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WithdrawManager : MonoBehaviour
{
    public Text bankBalanceText;        // ���� �ܾ� Text UI ���
    public Text cashText;               // ���� ���� Text UI ���
    public InputField inputField;       // ����� �ݾ��� �Է¹��� InputField UI ���
    public GameObject noMyCashImage;    // ���� ���� ������ ������ �̹��� UI ���
    public GameObject pausePanel;       // �Ͻ� ���� �г�

    private MainSceneUIManager mainUIManager; // ���ξ��� UI �Ŵ���


    void Start()
    {
        mainUIManager = FindObjectOfType<MainSceneUIManager>();
        // ���ξ��� UI �Ŵ��� ã��
        UpdateUI();
        // UI ������Ʈ
    }

    void UpdateUI()
    {
        bankBalanceText.text = "���� �ܾ�: " + mainUIManager.bankBalance.ToString() + "��";
        cashText.text = "���� ����: " + mainUIManager.cash.ToString() + "��";
    }

    public void TransferFromBankToCash()
    // ���࿡�� ���� �������� ��ü�ϴ� �Լ�
    {
        int amount = int.Parse(inputField.text);
        // �Էµ� �ݾ��� ������ ��ȯ

        if (mainUIManager.bankBalance >= amount)
        {
            mainUIManager.Withdraw(amount); 
            // ���࿡�� ����ϴ� �Լ� ȣ��
            UpdateUI();
            // UI ������Ʈ
            noMyCashImage.SetActive(false);
            // ���� ���� ���� �̹��� ��Ȱ��ȭ

            ResumeGame();
        }
        else
        {
            PauseGame(); // ���� �Ͻ� ����
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
        noMyCashImage.SetActive(false);
        // ���� ���� ���� �̹��� ��Ȱ��ȭ
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ð��� ����
        pausePanel.SetActive(true); // �Ͻ� ���� �г� Ȱ��ȭ
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // ���� �ð��� �ٽ� ����
        pausePanel.SetActive(false); // �Ͻ� ���� �г� ��Ȱ��ȭ
    }
}

