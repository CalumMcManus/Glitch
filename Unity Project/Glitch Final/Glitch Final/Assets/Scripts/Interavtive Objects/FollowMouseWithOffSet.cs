using UnityEngine;
using System.Collections;

public class FollowMouseWithOffSet : MonoBehaviour {
    [SerializeField] private Vector2 m_InfoBoxOffSet;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Input.mousePosition.x + m_InfoBoxOffSet.x, Input.mousePosition.y + m_InfoBoxOffSet.y);
	}
}
