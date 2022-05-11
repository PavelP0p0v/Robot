using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool z = false;
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape)){
            PauseChange();
         }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject temp = GameObject.Find("Main Camera");
            Mouse other = temp.GetComponent<Mouse>();
            other.enabled = z;
            z = !z;
           
        }
    }
    public string NextLevel;
    [SerializeField]
    GameObject PausePanel;

    [SerializeField]
    Button StartButton;
    [SerializeField]
    Button ExitButton;
    [SerializeField]
    Button MenuButton;

    private bool isPause = false;
    public PauseController Controller
    {
        get
        {
            return GameObject.Find("UIController").GetComponent<PauseController>();
        }
    }
    public void PauseChange()
    {
        isPause = !isPause;
        PausePanel.SetActive(isPause);
    }
    void Start()
    {
        StartButton.onClick.AddListener(OnStart);
        ExitButton.onClick.AddListener(OnExit);
        MenuButton.onClick.AddListener(OnMenu);
    }
    private void OnStart()
    {
        GameObject temp = GameObject.Find("Main Camera");
        Mouse other = temp.GetComponent<Mouse>();
        other.enabled = z;
        z = !z;
        PauseChange();
        Debug.Log("Продолжить");
    }
    private void OnMenu()
    {
        SceneManager.LoadScene(NextLevel);
        Debug.Log("Меню");
    }
    private void OnExit()
    {
        Application.Quit();
        Debug.Log("Выйти из игры");
    }
}
