using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{

    private static CharacterStats m_instance;

    public static CharacterStats Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }

    private int m_iMaxLives = 3;
    public int MaxLives { get { return m_iMaxLives; } set { m_iMaxLives = value; } }
    private int m_iCurrentLives = 3;
    public int CurrentLives {  get { return m_iCurrentLives; } set { m_iCurrentLives = value; } }

    [SerializeField] private int m_iMaxHealth = 100;
    public int MaxHealth { get { return m_iMaxHealth; } set { m_iMaxHealth = value; } }
    private int m_iCurrentHealth = 100;
    public int CurrentHealth { get { return m_iCurrentHealth; } set { m_iCurrentHealth = value; } }


    private int m_iMaxExp = 20;
    private int m_iCurrentExp = 0;
    public int CurrentExp { get { return m_iCurrentExp; } set { m_iCurrentExp = value; } }

        const int m_iMaxLevel = 15;
    private int m_CurrentLevel = 1;
    public int CurrentLevel { get { return m_CurrentLevel; } set { m_CurrentLevel = value; } }


        const int m_iMaxStrength = 20;
    private int m_iCurrentStrength = 0;
    public int CurrentStrength { get { return m_iCurrentStrength; } set { m_iCurrentStrength = value;  } }


        const int m_iMaxPlayerAccuracy = 20;
    private int m_iCurrentPlayerAccuracy = 0;
    public int PlayerAccuracy { get { return m_iCurrentPlayerAccuracy; } set { m_iCurrentPlayerAccuracy = value; } }


        const int m_iMaxIntellect = 20;
    private int m_iCurrentIntellect = 0;
    public int Intellect { get { return m_iCurrentIntellect; } set { m_iCurrentIntellect = value; } }


        const int m_iMaxAgility = 20;
    private int m_iCurrentAgility = 0;
    public int Agility {  get { return m_iCurrentAgility; } set { m_iCurrentAgility = value; } }


    const float m_fBaseSpeed = 8.0f;
    public float BaseSpeed { get { return m_fBaseSpeed; } }
    


    public void ModifyHealth(int healthChange)
    {
        if (healthChange < 0 && PlayerSkills.Instance.ReduceDmgTaken)
        {
            healthChange = (int)(healthChange * 0.9f);
        }
        CurrentHealth += healthChange;
        Mathf.Clamp(m_iCurrentHealth, -1, MaxHealth);
        if (m_iCurrentHealth <= 0)
        {

           UIManager.Instance.OpenDeathScreen(false);

        }
    }
    public void ModifyLives(int livesChange) // Get this looked at by Calum
    {
       
        CurrentLives += livesChange;
       Mathf.Clamp(m_iCurrentLives, -1, MaxLives);
        if (MaxLives <= 0)
        {
            // Game Over
        }
    }
    

    public void ModifyExp(int expchange)
    {
        CurrentExp += expchange;
        if (CurrentExp >= 100)
        {
            m_iCurrentExp -= 100;
            PlayerSkills.Instance.SkillPoints += 5;
            m_CurrentLevel++;
            PlayerSkills.Instance.LevelText.text = string.Format("Level: {0}", m_CurrentLevel);
        }

    }


}
