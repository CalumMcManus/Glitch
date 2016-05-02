using System.CodeDom;
using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    private static WeaponController m_instance;

    public static WeaponController Instance
    {
        get { return m_instance; }
    }

    [SerializeField] private Animator m_Anim;

    void Awake()
    {
        m_instance = this;
    }

    [SerializeField] private Weapon m_CurrentWeapon;
    public Weapon CurrentWeapon { get { return m_CurrentWeapon;} set { m_CurrentWeapon = value; CharMovement.Instance.UpdateSpeed(); } }
    private Weapon m_BaseWeapon;
    public Weapon BaseWeapon { set { m_BaseWeapon = value; } }
    private Weapon m_First;
    public Weapon First { set { m_First = value; } }
    private Weapon m_Second;
    public Weapon Second { set { m_Second = value; } }

	void Update () {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = m_BaseWeapon;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && m_First != null)
        {
            CurrentWeapon = m_First;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && m_Second  != null)
        {
            CurrentWeapon = m_Second;
        }

	    if (Input.GetButtonDown("Fire1") && m_CurrentWeapon != null)
	    {
            ShootAnim(true);
	        m_CurrentWeapon.SendMessage("Fire");
	    }
	}

    public void ShootAnim(bool shooting)
    {
        m_Anim.SetBool("Shooting", shooting);
    }
}
