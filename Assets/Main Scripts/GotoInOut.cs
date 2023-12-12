using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotoInOut : MonoBehaviour
{
    public Button inButton;
    public Button outButton;

    void Start()
    {
        inButton.onClick.AddListener(GoToInScene);
        outButton.onClick.AddListener(GoToOutScene);
    }

    public void GoToInScene()
    {
        SceneManager.LoadScene("InScene"); // �Ա�����
    }
    public void GoToOutScene()
    {
        SceneManager.LoadScene("OutScene"); // �������
    }
}
