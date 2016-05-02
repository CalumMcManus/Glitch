using UnityEngine;
using System.Collections;

public class ArmCanon : Weapon
{
    [SerializeField]
    private Projectile m_Projectile;
    [SerializeField]
    private Transform m_SpawnPoint;

    private Vector3 mousePos;

    private bool m_bCanFire = true;

    public void Fire()
    {
        StartCoroutine(ContinueFire());
    }

    private void Shoot()
    {
        CalculateAngle();
        Projectile projectile = Instantiate(m_Projectile, m_SpawnPoint.position, Quaternion.identity) as Projectile;
         if (Random.Range(0f, 100f) > m_iAccuracy)
         {
             float angleOffSet = Mathf.Abs(m_iAccuracy - 100);
             angleOffSet -= PlayerSkills.Instance.AccSkill;
             if (angleOffSet < 0) angleOffSet = 0;
             m_SpawnPoint.localEulerAngles = Random.Range(0, 2) == 0 ? new Vector3(m_SpawnPoint.localEulerAngles.x + angleOffSet, m_SpawnPoint.localEulerAngles.y, m_SpawnPoint.localEulerAngles.z) : new Vector3(m_SpawnPoint.localEulerAngles.x - angleOffSet, m_SpawnPoint.localEulerAngles.y, m_SpawnPoint.localEulerAngles.z);
         }
        projectile.transform.forward = m_SpawnPoint.forward;
        projectile.rBody.velocity = m_SpawnPoint.forward * 20;
        if (PlayerSkills.Instance.UpDamage)
        {
            projectile.Damage = (int)(m_iDamage*1.1f);
        }
        else
        {
            projectile.Damage = m_iDamage;
        }
        
        projectile.Range = m_iRange;
    }

    void CalculateAngle()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Camera.main.gameObject.transform.position.z));
        Vector3 vDir = (mousePos - m_SpawnPoint.position).normalized;
        Quaternion spawnRot = Quaternion.LookRotation(vDir, Vector3.forward);
        Vector3 spawnEular = spawnRot.eulerAngles;
        m_SpawnPoint.eulerAngles = spawnEular;
        m_SpawnPoint.localEulerAngles = new Vector3(ClampAngle(m_SpawnPoint.localEulerAngles.x, -45, 45), 90, 90);
       
    }
    float ClampAngle(float angle, float from, float to)
    {
        if (angle > 180) angle = angle - 360;
        angle = Mathf.Clamp(angle, from, to);
        if (angle < 0) angle = 360 + angle;

        return angle;
    }
    private IEnumerator ContinueFire()
    {
        while (Input.GetButton("Fire1"))
        {
            if (m_bCanFire)
            {
                m_bCanFire = false;
                Shoot();
                StartCoroutine(Buffer());
            }
            yield return new WaitForEndOfFrame();
        }
        WeaponController.Instance.ShootAnim(false);
    }

    private IEnumerator Buffer()
    {
        float rof = PlayerSkills.Instance.UpfireRate ? m_iRoF*1.1f : m_iRoF;
        float fTime = 0;
        while (fTime < rof)
        {
            fTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_bCanFire = true;
    }
}

