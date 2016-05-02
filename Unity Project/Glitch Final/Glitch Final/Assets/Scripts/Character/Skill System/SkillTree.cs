using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillTree : MonoBehaviour
{

    //tier 1 skill tree
    public Button btnArmedAndReady;
    [SerializeField] private Weapon m_BaseWeapon;

    //tier 2 skill tree
    public Button btnUpDamage;
    public Button btnUpFireRate;
    public Button btnReduceDmgTaken;

    //tier 3 skill tree
    public Button btnLaserCannon;
    public Button btnUzi;
    public Button btnSniperRifle;
    [SerializeField] private Weapon m_LaserCannon;
    [SerializeField] private Weapon m_Uzi;
    [SerializeField] private Weapon m_SniperRifle;


    //tier 4 skill tree
    public Button btnLaserTech;
    public Button btnBallistics;
    public Button btnLaserSights;

    //tier 5 skill tree
    public Button btnRailGun;
    public Button btnSubMachGun;
    public Button btnHeavySniperRifle;
    [SerializeField] private Weapon m_RailGun;
    [SerializeField] private Weapon m_SubMachineGun;
    [SerializeField] private Weapon m_HeavySniperRifle;


    //Info Text detailing skill tree functions
    public GameObject m_InfoBox;
    public Text m_Info;

    public void ArmedAndReadyInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Arm Cannon" + "\n" +
                    "Costs: 1 Skill Point";
    }

    public void UpDamageInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Increased damage on all weapons" + "\n" +
                    "Costs: 2 Skill Points";
    }

    public void UpFireRateInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Increased fire rate on all weapons" + "\n" + "Costs: 2 Skill Points";
    }

    public void ReduceDmgTakenInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: 10% Reduced damage" + "\n" + "Costs: 2 Skill Points";
    }

    public void LaserCannonInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Laser Cannon" + "\n" + "Costs: 3 Skill Points";
    }

    public void UziInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Uzi" + "\n" + "Costs: 3 Skill Points";
    }

    public void SniperRifleInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Sniper Rifle" + "\n" + "Costs: 3 Skill Points";
    }

    public void LaserTechInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Laser Cannon Buff" + "\n" + "Costs: 4 Skill Points";
    }

    public void BallisticsInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Uzi Buff" + "\n" + "Costs: 4 Skill Points";
    }

    public void LaserSightsInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Sniper Rifle Buff" + "\n" + "Costs: 4 Skill Points";
    }

    public void RailGunInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Rail Gun" + "\n" + "Costs: 5 Skill Points";
    }

    public void SubMachGunInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Sub Machine Gun" + "\n" + "Costs: 5 Skill Points";
    }

    public void HeavySniperRifleInfo()
    {
        m_InfoBox.SetActive(true);
        m_Info.text = "Unlocks: Heavy Sniper Rifle " + "\n" + "Costs: 5 Skill Points";
    }


    public void EmptyInfo()
    {
        m_InfoBox.SetActive(false);
        m_Info.text = "";
    }


    public void ArmedAndReady()
    {
        if(PlayerSkills.Instance.SkillPoints >= 1)
        {
            if(PlayerSkills.Instance.ArmedAndReady == false) 
			{ 
				PlayerSkills.Instance.SkillPoints -= 1;
				PlayerSkills.Instance.ArmedAndReady = true;
				btnArmedAndReady.interactable = false;
			    WeaponController.Instance.BaseWeapon = m_BaseWeapon;
			    WeaponController.Instance.CurrentWeapon = m_BaseWeapon;
			}
        }
    }



    public void UpDamage() 
	{ 
		if (btnArmedAndReady.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 2) 
			{
				if (PlayerSkills.Instance.UpDamage == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 2;
					PlayerSkills.Instance.UpDamage = true;
					btnUpDamage.interactable = false;
				}
			}
		}
	}

    public void UpFireRate() 
	{
		if (btnArmedAndReady.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 2) 
			{
				if (PlayerSkills.Instance.UpfireRate == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 2;
					PlayerSkills.Instance.UpfireRate = true;
					btnUpFireRate.interactable = false;
				}
			}
		}
	}

    public void ReduceDmgTaken() 
	{
		if (btnArmedAndReady.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 2) 
			{
				if (PlayerSkills.Instance.ReduceDmgTaken == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 2;
					PlayerSkills.Instance.ReduceDmgTaken = true;
					btnReduceDmgTaken.interactable = false;
				}
			}
		}
	}
    
	public void LaserCannon() 
	{
		if (btnReduceDmgTaken.interactable == false && btnUpDamage.interactable == false && btnUpFireRate.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 3) 
			{
				if (PlayerSkills.Instance.LaserCannon == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 3;
					PlayerSkills.Instance.LaserCannon = true;
					btnLaserCannon.interactable = false;
				    btnUzi.interactable = false;
				    btnSniperRifle.interactable = false;
				    WeaponController.Instance.First = m_LaserCannon;
				}
			}
		}
	}

    public void Uzi() 
	{
		if (btnReduceDmgTaken.interactable == false && btnUpDamage.interactable == false && btnUpFireRate.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 3) 
			{
				if (PlayerSkills.Instance.Uzi == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 3;
					PlayerSkills.Instance.Uzi = true;
					btnUzi.interactable = false;
                    btnLaserCannon.interactable = false;
                    btnSniperRifle.interactable = false;
                    WeaponController.Instance.First = m_Uzi;
				}
			}
		}
	}

    public void SniperRifle() 
	{
		if (btnReduceDmgTaken.interactable == false && btnUpDamage.interactable == false && btnUpFireRate.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 3) 
			{
				if (PlayerSkills.Instance.SniperRifle == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 3;
					PlayerSkills.Instance.SniperRifle = true;
					btnSniperRifle.interactable = false;
                    btnLaserCannon.interactable = false;
				    btnUzi.interactable = false;
                    WeaponController.Instance.First = m_SniperRifle;
				}
			}
		}
	}
    
	public void LaserTech() 
	{
		if (btnLaserCannon.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 4) 
			{
				if (PlayerSkills.Instance.LaserTech == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 4;
					PlayerSkills.Instance.LaserTech = true;
					btnLaserTech.interactable = false;
				}
			}
		}
	}
    
	public void Ballistics() 
	{
		if (btnUzi.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 4) 
			{
				if (PlayerSkills.Instance.Ballistics == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 4;
					PlayerSkills.Instance.Ballistics = true;
					btnBallistics.interactable = false;
				}
			}
		}
	}
    
	public void LaserSights() 
	{ 
		if (btnSniperRifle.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 4) 
			{
				if (PlayerSkills.Instance.Ballistics == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 4;
					PlayerSkills.Instance.LaserSights = true;
					btnLaserSights.interactable = false;
				}
			}
		}
	}
    
	public void RailGun() 
	{
		if (btnLaserTech.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 5) 
			{
				if (PlayerSkills.Instance.RailGun == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 5;
					PlayerSkills.Instance.RailGun = true;
					btnRailGun.interactable = false;
				    btnSubMachGun.interactable = false;
				    btnHeavySniperRifle.interactable = false;
                    WeaponController.Instance.Second = m_RailGun;
				}
			}
		}
	}
    public void SubMachGun() 
	{
		if (btnBallistics.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 5) 
			{
				if (PlayerSkills.Instance.SubMachGun == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 5;
					PlayerSkills.Instance.SubMachGun = true;
					btnSubMachGun.interactable = false;
                    WeaponController.Instance.Second = m_SubMachineGun;
				}
			}
		}
	}
    public void HeavySniperRifle() 
	{
		if (btnLaserSights.interactable == false) 
		{
			if (PlayerSkills.Instance.SkillPoints >= 5) 
			{
				if (PlayerSkills.Instance.HeavySniperRifle == false) 
				{ 
					PlayerSkills.Instance.SkillPoints -= 5;
					PlayerSkills.Instance.HeavySniperRifle = true;
					btnHeavySniperRifle.interactable = false;
                    WeaponController.Instance.Second = m_HeavySniperRifle;
				}
			}
		}
	}
  
}