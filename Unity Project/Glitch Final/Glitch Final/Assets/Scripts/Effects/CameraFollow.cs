using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform m_Target;

    void Update()
    {
        transform.position = new Vector3(m_Target.position.x, m_Target.position.y+7.3f, transform.position.z);
    }
}
