using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    [SerializeField] private Text m_Text;
    [SerializeField] private float m_fPrintDelay;
    [SerializeField] private GameObject m_ObjFunction;
    [SerializeField] private string m_sFunctionName;
    private string m_sText;

	// Use this for initialization
	void Start ()
	{
	    m_sText = m_Text.text;
	    m_Text.text = string.Empty;
	    StartCoroutine(Print());
	}

    private IEnumerator Print()
    {
        int i = 0;
        while (i < m_sText.Length)
        {
            char c = m_sText[i];
            m_Text.text += c;
            i++;
            yield return new WaitForSeconds(m_fPrintDelay);
        }

        if (m_ObjFunction)
        {
            m_ObjFunction.SendMessage(m_sFunctionName);
        }
    }
}
