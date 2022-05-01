using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string NextLevel;
    [SerializeField]
    GameObject MenuPanel;

    [SerializeField]
    Button StartButton;
    [SerializeField]
    Button ExitButton;

    public MenuController Controller
    {
        get
        {
           return GameObject.Find("UIController").GetComponent<MenuController>();
        }
    }

    void Start()
    {
        StartButton.onClick.AddListener(OnStart);
        ExitButton.onClick.AddListener(OnExit);
    }
    private void OnStart()
    {
        SceneManager.LoadScene(NextLevel);
        Debug.Log("Играть");
    }
    private void OnExit()
    {
        Application.Quit();
        Debug.Log("Выход");
    }
}
