using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Slider Health;
	public Slider Exp;



	
	// Update is called once per frame
	void Update () 
	{
		
		Health.maxValue = CharacterStats.Instance.MaxHealth;
		Health.minValue = 0;
		Health.value = CharacterStats.Instance.CurrentHealth;

		Exp.maxValue = 100;
		Exp.minValue = 0;
		Exp.value = CharacterStats.Instance.CurrentExp;
		
	}
}
