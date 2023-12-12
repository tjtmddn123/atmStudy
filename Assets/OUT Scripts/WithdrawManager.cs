using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WithdrawManager : MonoBehaviour
{
    public Text bankBalanceText;        // 은행 잔액 Text UI 요소
    public Text cashText;               // 보유 현금 Text UI 요소
    public InputField inputField;       // 출금할 금액을 입력받을 InputField UI 요소
    public GameObject noMyCashImage;    // 보유 현금 부족시 보여줄 이미지 UI 요소
    public GameObject pausePanel;       // 일시 정지 패널

    private MainSceneUIManager mainUIManager; // 메인씬의 UI 매니저


    void Start()
    {
        mainUIManager = FindObjectOfType<MainSceneUIManager>();
        // 메인씬의 UI 매니저 찾기
        UpdateUI();
        // UI 업데이트
    }

    void UpdateUI()
    {
        bankBalanceText.text = "은행 잔액: " + mainUIManager.bankBalance.ToString() + "원";
        cashText.text = "보유 현금: " + mainUIManager.cash.ToString() + "원";
    }

    public void TransferFromBankToCash()
    // 은행에서 보유 현금으로 이체하는 함수
    {
        int amount = int.Parse(inputField.text);
        // 입력된 금액을 정수로 변환

        if (mainUIManager.bankBalance >= amount)
        {
            mainUIManager.Withdraw(amount); 
            // 은행에서 출금하는 함수 호출
            UpdateUI();
            // UI 업데이트
            noMyCashImage.SetActive(false);
            // 보유 현금 부족 이미지 비활성화

            ResumeGame();
        }
        else
        {
            PauseGame(); // 게임 일시 정지
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
        noMyCashImage.SetActive(false);
        // 보유 현금 부족 이미지 비활성화
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // 게임 시간을 멈춤
        pausePanel.SetActive(true); // 일시 정지 패널 활성화
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // 게임 시간을 다시 시작
        pausePanel.SetActive(false); // 일시 정지 패널 비활성화
    }
}

