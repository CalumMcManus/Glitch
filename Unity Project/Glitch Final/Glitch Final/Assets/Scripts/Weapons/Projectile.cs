using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    private int m_iDamage;
    public int Damage { get { return m_iDamage; } set { m_iDamage = value; } }
    private int m_iRange;
    public int Range { get { return m_iRange; } set { m_iRange = value; } }
    private Rigidbody m_body;
    public Rigidbody rBody 
    {
        get { return m_body ?? (m_body = GetComponent<Rigidbody>()); }
    }

    private Vector3 startPos;
    private bool m_bHasCollided = false;

    void Awake()
    {
        startPos = transform.position;
        startPos = new Vector3(startPos.x, startPos.y, 0);
        transform.position = startPos;  
    }

    void Update()
    {
        float dist = Vector3.Distance(startPos, transform.position);
        if (dist > Range)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (m_bHasCollided) return;
        m_bHasCollided = true;
        if (col.transform.tag == "Enemy")
        {
            col.transform.GetComponent<EnemyStats>().ModifyHealth(-m_iDamage);
            Destroy(gameObject);
        }
        else if (col.transform.tag == "Player")
        {
            col.transform.GetComponent<CharacterStats>().ModifyHealth(-m_iDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

}
