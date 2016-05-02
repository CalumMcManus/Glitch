using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private float m_fMoveDist;
    [SerializeField] private float m_TimeTaken;
    [SerializeField] private bool m_bUp;
    [SerializeField] private bool m_bSideWays;

    private Vector3 m_StartPos;
    private Vector3 m_EndPos;

    void Awake()
    {
        m_StartPos = transform.position;
        m_EndPos = transform.position;
        if (m_bUp)
        {
            m_EndPos = new Vector3(m_EndPos.x, m_EndPos.y + m_fMoveDist, m_EndPos.z);
        }
        if (m_bSideWays)
        {
            m_EndPos = new Vector3(m_EndPos.x + m_fMoveDist, m_EndPos.y, m_EndPos.z);
        }
    }

    void OnEnable()
    {
        transform.position = m_StartPos;
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        float lerp = 0;
        while (gameObject.activeInHierarchy)
        {
            lerp = 0;
            yield return new WaitForEndOfFrame();
            while (lerp < 1)
            {
                yield return new WaitForEndOfFrame();
                lerp += Time.deltaTime/m_TimeTaken;
                transform.position = Vector3.Lerp(m_StartPos, m_EndPos, lerp);
            }
            lerp = 0;
            while (lerp < 1)
            {
                yield return new WaitForEndOfFrame();
                lerp += Time.deltaTime/m_TimeTaken;
                transform.position = Vector3.Lerp(m_EndPos, m_StartPos, lerp);
            }
        }
        
    }
}
