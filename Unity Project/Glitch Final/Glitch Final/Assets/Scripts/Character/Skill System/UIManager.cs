using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    private static UIManager m_instance;

    public static UIManager Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }

	[SerializeField] private GameObject StatScreen;
	[SerializeField] private GameObject UIOverlay;
	[SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject m_GameOver;
	private bool m_bMenuOpen = false;

	void Update()
	{
		if(Input.GetButtonDown("Pause"))
		{
			if (StatScreen.activeInHierarchy == false) 
			{
				OpenMenu ();
			}
			if (StatScreen.activeInHierarchy == true) 
			{
				UIOverlay.SetActive (true);
				PauseMenu.SetActive (false);
				StatScreen.SetActive (false);
				Time.timeScale = 1;
			}
		}
	}

	public void OpenMenu()
	{
		if (!m_bMenuOpen) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}
		m_bMenuOpen = !m_bMenuOpen;
	}

	public void OpenStatScreen()
	{	
		//Time.timeScale = 0;
		UIOverlay.SetActive (false);
		PauseMenu.SetActive (false);
		StatScreen.SetActive (true);

	}

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenDeathScreen(bool success)
    {
        //Time.timeScale = 0;
        m_GameOver.SetActive(true);
        if (success)
        {
            m_GameOver.transform.GetChild(2).transform.gameObject.SetActive(true);
        }
        else
        {
            m_GameOver.transform.GetChild(1).transform.gameObject.SetActive(true);
        }
        
    }


}