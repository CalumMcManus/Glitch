using UnityEngine;
using System.Collections;

public class LaserEffect : MonoBehaviour
{

    [SerializeField] private Transform m_Main;
    [SerializeField] private Transform m_Second;
    [SerializeField] private float m_fSpeed;
	void Update () {
	    m_Main.Rotate(0, 0, m_fSpeed*Time.deltaTime);
        m_Second.Rotate(0, 0, -m_fSpeed * Time.deltaTime);
	}
}
