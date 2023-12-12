using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DepositManager : MonoBehaviour
{
    public Text bankBalanceText;        // 은행 잔액 Text UI 요소
    public Text cashText;               // 보유 현금 Text UI 요소
    public InputField inputField;       // 금액을 입력받을 InputField UI 요소
    public GameObject noMyCashImage;    // 보유 현금이 부족할 때 보여줄 이미지 UI 요소
    public GameObject pausePanel;       // 일시 정지 패널

    private MainSceneUIManager mainUIManager; // 메인씬의 UI 매니저


    void Start()
    {
        mainUIManager = FindObjectOfType<MainSceneUIManager>(); // MainSceneUIManager를 찾음
        UpdateUI();  // 시작할 때 UI 업데이트
    }

    void UpdateUI()
    {
        bankBalanceText.text = "은행 잔액: " + mainUIManager.bankBalance.ToString() + "원"; 
        // 은행 잔액 UI 업데이트
        cashText.text = "보유 현금: " + mainUIManager.cash.ToString() + "원";              
        // 보유 현금 UI 업데이트
    }

    public void TransferFromCashToBank()
    {
        int amount = int.Parse(inputField.text); 
        // 입력된 금액을 정수로 변환

        if (mainUIManager.cash >= amount)
        {
            mainUIManager.Deposit(amount); 
            // 메인씬의 UI 매니저를 통해 입금 기능 수행
            UpdateUI();  // UI 업데이트

            noMyCashImage.SetActive(false);
            // 보유 현금 부족 이미지 비활성화

            ResumeGame();
        }
        else
        {
            PauseGame();
            noMyCashImage.SetActive(true); 
            // 보유 현금 부족 이미지 활성화
        }
    }

    // 각 버튼을 눌렀을 때 해당 금액을 인풋 필드에 설정하는 함수들
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
        ResumeGame(); // 게임 재개
        noMyCashImage.SetActive(false); // 패널 비활성화
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // 게임 시간을 멈춤
        pausePanel.SetActive(true); // 일시 정지 패널 활성화
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // 게임 시간을 다시 시
        pausePanel.SetActive(false); // 일시 정지 패널 비활성화
    }
}

