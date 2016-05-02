using UnityEngine;
using System.Collections;

public class LazerWeapon : Weapon
{

    [SerializeField]
    private Lazer m_Lazer;
    [SerializeField]
    private Transform m_SpawnPoint;

    private bool m_bCanFire = true;

    public void Fire()
    {
        m_Lazer.Damage = m_iDamage;
        m_Lazer.Range = m_iRange;
        m_Lazer.LazerSetUp();
        StartCoroutine(ContinueFire());
    }

    private void Shoot()
    {
        m_Lazer.DealDamage();
    }

    void CalculateAngle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Camera.main.gameObject.transform.position.z));
        Vector3 vDir = (mousePos - m_SpawnPoint.position).normalized;
        Quaternion spawnRot = Quaternion.LookRotation(vDir, Vector3.forward);
        Vector3 spawnEular = spawnRot.eulerAngles;
        m_SpawnPoint.eulerAngles = spawnEular;
        m_SpawnPoint.localEulerAngles = new Vector3(ClampAngle(m_SpawnPoint.localEulerAngles.x, -45, 45), 90, 90);
        m_Lazer.transform.localEulerAngles = new Vector3(ClampAngle(m_SpawnPoint.localEulerAngles.x, -45, 45), 90, 90);     
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
        m_Lazer.gameObject.SetActive(true);
        while (Input.GetButton("Fire1"))
        {
            CalculateAngle();
            if (m_bCanFire)
            {
                m_bCanFire = false;
                Shoot();
                StartCoroutine(Buffer());
            }
            yield return new WaitForEndOfFrame();
        }
        WeaponController.Instance.ShootAnim(false);
        m_Lazer.gameObject.SetActive(false);
    }

    private IEnumerator Buffer()
    {
        float fTime = 0;
        while (fTime < m_iRoF)
        {
            fTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_bCanFire = true;
    }
}
