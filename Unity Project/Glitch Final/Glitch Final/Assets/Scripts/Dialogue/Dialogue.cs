using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    private static Dialogue m_instance;

    public static Dialogue Instance
    {
        get { return m_instance; }
    }

    void Awake()
    {
        m_instance = this;
    }

    [SerializeField] private GameObject m_Dialogue;
    [SerializeField] private Text m_Text;

    private string m_sInfo = "A - Moves Player Left\nD - Moves Player Right\nC - Activates CodeView While Held\nLeft Mouse Click - Fire Weapon\n1,2,3 - Cycle Through Weapons\nEsc - Open/Close Menu | H - Reopens this box\nSpend Skill Points in the Menu! (You get 5 points per level)";
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            m_Dialogue.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            NewDialogue(m_sInfo);
        }
	}

    public void NewDialogue(string text)
    {
        m_Text.text = text;
        m_Dialogue.SetActive(true);
    }

    public void CloseDialogue()
    {
        m_Dialogue.SetActive(false);
    }
}
