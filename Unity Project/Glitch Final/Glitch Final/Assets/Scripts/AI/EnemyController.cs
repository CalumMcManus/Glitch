using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private Animator m_Anim;
    [SerializeField] private float m_Speed;
    [SerializeField] private Projectile m_Projectile;
    [SerializeField] private Transform m_ProjSpawn;
    [SerializeField] private int m_iDamage;
    [SerializeField] private bool m_bCanMove = false;
    private CharacterController m_Controller;
    private EnemyStats m_Stats;
    private bool m_bAware = false;
    [SerializeField] private float m_fLoadTime = 1;
    private float m_fTimeTillLoaded = 0;
    [SerializeField] private bool m_isBoss;
    private bool m_bIsDead = false;
    

    void Start()
    {
        m_Stats = GetComponent<EnemyStats>();
        m_Controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (m_Stats.CurrentHealth <= 0 && !m_bIsDead)
        {
            m_bIsDead = true;
           if(m_isBoss)  UIManager.Instance.OpenDeathScreen(true);
        }
        if (m_bIsDead) return;
        transform.localEulerAngles = m_Target.position.x < transform.position.x ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
        if (CheckDistFromTarget() <= m_Stats.Range)
        {
            if (!m_bAware)
            {
                Vector3 vDir = (m_Target.position - transform.position).normalized;
                Ray ray = new Ray(transform.position, vDir);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, m_Stats.Range))
                {
                    if (hit.collider.tag == "Player")
                    {
                        m_bAware = true;
                    }
                }
            }
            m_fTimeTillLoaded += Time.deltaTime;
            if (m_fTimeTillLoaded >= m_fLoadTime)
            {
                Vector3 vDir = (m_Target.position - transform.position).normalized;
                Projectile proj = Instantiate(m_Projectile, m_ProjSpawn.position, Quaternion.identity) as Projectile;
                proj.Damage = m_iDamage;
                proj.Range = m_Stats.Range;
                if (m_isBoss) proj.transform.localScale = proj.transform.localScale*5;
                proj.transform.LookAt(m_Target);
                proj.rBody.velocity = proj.transform.forward * 20;
                m_fTimeTillLoaded = 0;
            }

            m_Anim.SetBool("Shooting", m_bAware);
            m_Anim.SetBool("Running", false);
        }

        if (CheckDistFromTarget() > m_Stats.Range && m_bAware && m_bCanMove)
        {
            m_Controller.SimpleMove((transform.right*m_Speed)*Time.deltaTime);
            m_Anim.SetBool("Running", true);
            m_Anim.SetBool("Shooting", false);
        }
        

    }

    float  CheckDistFromTarget()
    {
        return Vector3.Distance(transform.position, m_Target.position);
    }


}
