using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public Text bankBalanceText;    // ���� �ܾ��� ǥ���� Text UI ���
    public Text cashText;           // ���� ������ ǥ���� Text UI ���

    public int bankBalance = 50000;    // �ʱ� ���� �ܾ�
    public int cash = 100000;          // �ʱ� ���� ����

    void Start()
    {
        UpdateUI();  // ������ �� UI ������Ʈ
    }

    void Update()
    {
        UpdateUI(); // �ֱ������� UI ������Ʈ
    }

    void UpdateUI()
    {
        bankBalanceText.text = "���� �ܾ�: " + bankBalance.ToString() + "��"; 
        // ���� �ܾ� UI ������Ʈ
        cashText.text = "���� ����: " + cash.ToString() + "��";              
        // ���� ���� UI ������Ʈ
    }

    // �Ա� ���
    public void Deposit(int depositAmount)
    {
        bankBalance += depositAmount;   // ���� �ܾ׿� �Ա��� �ݾ��� �߰�
        cash -= depositAmount;         // ���� ���ݿ��� �Ա��� �ݾ��� ����
    }

    // ��� ���
    public void Withdraw(int withdrawAmount)
    {
        bankBalance -= withdrawAmount; // ���� �ܾ׿��� ����� �ݾ��� ����
        cash += withdrawAmount;        // ���� ���ݿ� ����� �ݾ��� �߰�
    }
}

