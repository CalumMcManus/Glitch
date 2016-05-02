
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerSkills : MonoBehaviour
{
    private static PlayerSkills m_instance;

    public static PlayerSkills Instance
    {
        get { return m_instance; }
    }

    void Awake()
    {
        m_instance = this;
    }

	void Update()
	{
		//foreach (int Skill in m_iHealthSkill) {CharacterStats.Instance.MaxHealth *= 1.05f;}
		//foreach (int Skill in m_iStrengthSkill) {CharacterStats.Instance.CurrentStrength *= 1.05f;}
		//foreach (int Skill in m_iAccSkill) {CharacterStats.Instance.PlayerAccuracy *= 1.05f;}
		//foreach (int Skill in m_iIntelSkill) {CharacterStats.Instance.Intellect *= 1.05f;}
		//foreach (int Skill in m_iAgilitySkill) {CharacterStats.Instance.Agility *= 1.05f;}

	}
		
	//stat based skill points
    private int m_iSkillPoints = 1; //On Level up, increment this value by 10 or some other number.
    public int SkillPoints { get { return m_iSkillPoints; } set { m_iSkillPoints = value; } }

    private int m_iHealthSkill = 0;
    public int HealthSkill { get { return m_iHealthSkill; } set { m_iHealthSkill = value; CharacterStats.Instance.MaxHealth += 10; } }

    private int m_iStrengthSkill = 0;
    public int StrengthSkill { get { return m_iStrengthSkill; } set { m_iStrengthSkill = value; CharMovement.Instance.UpdateSpeed(); } }

    private int m_iAccSkill = 0;
    public int AccSkill { get { return m_iAccSkill; } set { m_iAccSkill = value; } }

    private int m_iIntelSkill = 0;
    public int IntelSkill { get { return m_iIntelSkill; } set { m_iIntelSkill = value; } }

    [SerializeField] private int m_iAgilitySkill = 0;
    public int AgilitySkill { get { return m_iAgilitySkill; } set { m_iAgilitySkill = value; CharMovement.Instance.UpdateSpeed(); } }


    //skill tree boolean values for unlocked weapons and upgrades
    private bool m_bArmedAndReadyActive = false;
    public bool ArmedAndReady { get { return m_bArmedAndReadyActive; } set { m_bArmedAndReadyActive = value; } }

    private bool m_bUpDamage = false;
    public bool UpDamage { get { return m_bUpDamage; } set { m_bUpDamage = value; } }

    private bool m_bUpFireRate = false;
    public bool UpfireRate { get { return m_bUpFireRate; } set { m_bUpFireRate = value; } }

    private bool m_bReduceDmgTaken = false;
    public bool ReduceDmgTaken { get { return m_bReduceDmgTaken; } set { m_bReduceDmgTaken = value; } }

    private bool m_bLaserCannon = false;
    public bool LaserCannon { get { return m_bLaserCannon; } set { m_bLaserCannon = value; } }

    private bool m_bUzi = false;
    public bool Uzi { get { return m_bUzi; } set { m_bUzi = value; } }

    private bool m_bSniperRifle = false;
    public bool SniperRifle { get { return m_bSniperRifle; } set { m_bSniperRifle = value; } }

    private bool m_bLaserTech = false;
    public bool LaserTech { get { return m_bLaserTech; } set { m_bLaserTech = value; } }

    private bool m_bBallistics = false;
    public bool Ballistics { get { return m_bBallistics; } set { m_bBallistics = value; } }

    private bool m_bLaserSights = false;
    public bool LaserSights { get { return m_bLaserSights; } set { m_bLaserSights = value; } }

    private bool m_bRailGun = false;
    public bool RailGun { get { return m_bRailGun; } set { m_bRailGun = value; } }

    private bool m_bSubMachGun = false;
    public bool SubMachGun { get { return m_bSubMachGun; } set { m_bSubMachGun = value; } }

    private bool m_bHeavySniperRifle = false;
    public bool HeavySniperRifle { get { return m_bHeavySniperRifle; } set { m_bHeavySniperRifle = value; } }

    [SerializeField] private Text m_Level;
    public Text LevelText { get { return m_Level; } }

}





