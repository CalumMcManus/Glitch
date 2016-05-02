using UnityEngine;
using System.Collections;

public class DealthSparkle : MonoBehaviour
{

	void Update ()
	{
        transform.Rotate(0, 0, 50 * Time.deltaTime);
	}
}
