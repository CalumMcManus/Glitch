using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        float multiplier;
        if(col.gameObject.tag == "Health_Pickup")
        {
            multiplier = (PlayerSkills.Instance.IntelSkill*0.03f)+0.15f;
            CharacterStats.Instance.CurrentHealth += Mathf.RoundToInt(CharacterStats.Instance.MaxHealth * multiplier);
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Ammo_Pickup")
        {
            multiplier = (PlayerSkills.Instance.IntelSkill * 0.02f) + 0.05f;
            WeaponController.Instance.CurrentWeapon.m_iAmmo += Mathf.RoundToInt(WeaponController.Instance.CurrentWeapon.m_iMaxAmmo * multiplier);
            Destroy(col.gameObject);
        }
        
    }
}
