using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public Button startButton;
    public Button creditsButton;
    public Button exitButton;
    public Button returnButton;
    GameObject MainMenu;
    GameObject CreditScreen;

    private void Awake()
    {
        Button StartButton = startButton.GetComponent<Button>();
        StartButton.onClick.AddListener(BeginGame);
        Button CreditsButton = creditsButton.GetComponent<Button>();
        CreditsButton.onClick.AddListener(CreditOpen);
        Button ReturnButton = returnButton.GetComponent<Button>();
        ReturnButton.onClick.AddListener(CreditClose);
        Button ExitButton = exitButton.GetComponent<Button>();
        ExitButton.onClick.AddListener(EndGame);
        MainMenu = GameObject.Find("MainMenu");
        CreditScreen = GameObject.Find("CreditScreen");
    }
    // Use this for initialization
    void Start () {
        CreditScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    void CreditOpen()
    {
        CreditScreen.SetActive(true);
        MainMenu.SetActive(false);
    }

    void CreditClose()
    {
        MainMenu.SetActive(true);
        CreditScreen.SetActive(false);
    }

    void EndGame()
    {
        Application.Quit();
    }

}
