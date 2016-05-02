using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lazer : MonoBehaviour {

    private int m_iDamage;
    public int Damage { get { return m_iDamage; } set { m_iDamage = value; } }
    private int m_iRange;
    public int Range { get { return m_iRange; } set { m_iRange = value; } }
    private List<EnemyStats> m_Enemies = new List<EnemyStats>();
    public List<EnemyStats> Enemies { get { return m_Enemies; } }
 

    public void LazerSetUp()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, m_iRange);
    }

    public void DealDamage()
    {
        for(int i = 0; i < m_Enemies.Count; i++)
        {
            if (m_Enemies[i])
            {
                m_Enemies[i].ModifyHealth(-m_iDamage);
            }
            else
            {
                m_Enemies.RemoveAt(i);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyStats eStats = other.GetComponent<EnemyStats>();
        if (eStats)
        {
            m_Enemies.Add(eStats);
        }
    }

    void OnTriggerExit(Collider other)
    {
        EnemyStats eStats = other.GetComponent<EnemyStats>();
        if (m_Enemies.Contains(eStats))
        {
            m_Enemies.Remove(eStats);
        }
    }
}
