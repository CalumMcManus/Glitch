using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class CodeView : MonoBehaviour
{

    private static CodeView m_instance;

    public static CodeView Instance
    {
        get { return m_instance; }
    }

    private void Awake()
    {
        m_instance = this;
    }

    [SerializeField] private Transform m_BuildingParent;
    [SerializeField] private Transform m_CodeObjectParent;
    [SerializeField] private List<Material> m_ColourMaterials = new List<Material>();
    [SerializeField] private Material m_GreyScale;

    public void PushToList(GameObject obj)
    {
        obj.transform.SetParent(m_CodeObjectParent);
    }

    private void Update()
    {
        if (Input.GetButtonDown("CodeView"))
        {
            for (int i = 0; i < m_CodeObjectParent.childCount; i++)
            {
                m_CodeObjectParent.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < m_BuildingParent.childCount; i++)
            {
                MeshRenderer r = m_BuildingParent.GetChild(i).GetComponent<MeshRenderer>();
                if (r) r.material = m_GreyScale;
            }
        }
        if (Input.GetButtonUp("CodeView"))
        {
            for (int i = 0; i < m_CodeObjectParent.childCount; i++)
            {
                m_CodeObjectParent.GetChild(i).gameObject.SetActive(false);
            }


            for (int i = 0; i < m_BuildingParent.childCount; i++)
            {
              MeshRenderer r =  m_BuildingParent.GetChild(i).GetComponent<MeshRenderer>();
              if(r)  r.material = m_ColourMaterials[Random.Range(0, m_ColourMaterials.Count)];
            }
        }
    }
}
