using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public Text bankBalanceText;    // 은행 잔액을 표시할 Text UI 요소
    public Text cashText;           // 보유 현금을 표시할 Text UI 요소

    public int bankBalance = 50000;    // 초기 은행 잔액
    public int cash = 100000;          // 초기 보유 현금

    void Start()
    {
        UpdateUI();  // 시작할 때 UI 업데이트
    }

    void Update()
    {
        UpdateUI(); // 주기적으로 UI 업데이트
    }

    void UpdateUI()
    {
        bankBalanceText.text = "은행 잔액: " + bankBalance.ToString() + "원"; 
        // 은행 잔액 UI 업데이트
        cashText.text = "보유 현금: " + cash.ToString() + "원";              
        // 보유 현금 UI 업데이트
    }

    // 입금 기능
    public void Deposit(int depositAmount)
    {
        bankBalance += depositAmount;   // 은행 잔액에 입금한 금액을 추가
        cash -= depositAmount;         // 보유 현금에서 입금한 금액을 감소
    }

    // 출금 기능
    public void Withdraw(int withdrawAmount)
    {
        bankBalance -= withdrawAmount; // 은행 잔액에서 출금한 금액을 차감
        cash += withdrawAmount;        // 보유 현금에 출금한 금액을 추가
    }
}

