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
        SceneManager.LoadScene("InScene"); // 입금으로
    }
    public void GoToOutScene()
    {
        SceneManager.LoadScene("OutScene"); // 출금으로
    }
}
