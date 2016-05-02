using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    private static EnemyStats m_instance;

    public static EnemyStats Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }

    [SerializeField] private Animator m_Anim;
    [SerializeField] private ParticleSystem m_DeathSparkle;
    [SerializeField] private int m_iMaxHealth = 50;
    public int MaxHealth { get { return m_iMaxHealth; } set { m_iMaxHealth = value; } }
    [SerializeField] private int m_iCurrentHealth;
    public int CurrentHealth { get { return m_iCurrentHealth; } set { m_iCurrentHealth = value; } }

    [SerializeField] private int m_iRange;
    public int Range { get { return m_iRange; } }
    [SerializeField] private int m_iExp;

    [SerializeField] private GameObject m_PickUpPrefab;
    private bool m_bDead = false;

    void Start()
    {
        m_iCurrentHealth = m_iMaxHealth;
    }

    public void ModifyHealth(int healthChange)
    {
        CurrentHealth += healthChange;
        Mathf.Clamp(m_iCurrentHealth, -1, MaxHealth);
        if (m_iCurrentHealth <= 0 && !m_bDead)
        {
            m_bDead = true;
            
            if (Random.Range(0f, 1f) < 0.6f)
            {
                GameObject Pickup = Instantiate(m_PickUpPrefab, transform.position, Quaternion.identity) as GameObject;
                Pickup.tag = Random.Range(0f, 1f) < 2  ? "Health_Pickup" : "Ammo_Pickup"; // Fix this for ammo pick ups
                CodeView.Instance.PushToList(Pickup);
            }
            CharacterStats.Instance.ModifyExp(m_iExp);
            m_Anim.SetTrigger("Death");
            m_DeathSparkle.gameObject.SetActive(true);
            m_Anim.SetBool("Shooting", false);
            m_Anim.SetBool("Idle", false);
            StartCoroutine(Death());

        }


    }

    private IEnumerator Death()
    {
        float f = 0;
        while (f < 10)
        {
            f += Time.deltaTime;
            transform.Translate(Vector3.up*5*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}