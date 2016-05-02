using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{

    [SerializeField] private float m_fDelay;
    [SerializeField] private int m_iSceneIndex;
    [SerializeField] private bool m_bOnSpace;
    private bool m_bHasCalled = false;


    void Update()
    {
        if (m_bOnSpace)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene();
            }
        }
    }

    public void LoadScene()
    {
        if (m_bHasCalled) return;
        m_bHasCalled = true;
        if (m_fDelay > 0)
        {
            StartCoroutine(Delay());
            return;
        }
        SceneManager.LoadScene(m_iSceneIndex);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(m_fDelay);
        SceneManager.LoadScene(m_iSceneIndex);
    }
}
