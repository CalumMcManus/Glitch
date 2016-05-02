using UnityEngine;
using System.Collections;

public class FadeInCanvasGroup : MonoBehaviour
{

    [SerializeField] private CanvasGroup m_CavasGroup;
    [SerializeField] private float m_fTimeToFade;
    [SerializeField] private GameObject m_ObjFunction;
    [SerializeField] private string m_sFunctionName;
    [SerializeField] private bool m_bOnSpace;

    private bool m_bHasStarted = false;

    void Update()
    {
        if (m_bOnSpace && Input.GetKeyDown(KeyCode.Space))
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        if (!m_bHasStarted)
        {
            m_bHasStarted = true;
            StartCoroutine(FadeInEnum());
        }
    }

    public void FadeOut()
    {
        if (!m_bHasStarted)
        {
            m_bHasStarted = true;
            StartCoroutine(FadeOutEnum());
        }
    }

    private IEnumerator FadeInEnum()
    {
        float fade = 0;
        while (fade < 1)
        {
            fade += Time.deltaTime/m_fTimeToFade;
            m_CavasGroup.alpha = fade;
            yield return new WaitForEndOfFrame();
        }
        if (m_ObjFunction)
        {
            m_ObjFunction.SendMessage(m_sFunctionName);
        }
    }

    private IEnumerator FadeOutEnum()
    {
        float fade = 1;
        while (fade > 0)
        {
            fade -= Time.deltaTime / m_fTimeToFade;
            m_CavasGroup.alpha = fade;
            yield return new WaitForEndOfFrame();
        }
        if (m_ObjFunction)
        {
            m_ObjFunction.SendMessage(m_sFunctionName);
        }
    }
}
