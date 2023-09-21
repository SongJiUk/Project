using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandSpearSkill_2 : _ObjectMakeBase
{

    public bool CheckScriptLoad;

    public Vector3 m_randomRotationValue;
    List<GameObject> list = new List<GameObject>();

    private void OnEnable()
    {

        for (int i = 0; i < m_makeObjs.Length; i++)
        {
            GameObject m_obj = Instantiate(m_makeObjs[i], transform.position, transform.rotation);
            m_obj.transform.parent = this.transform;
            m_obj.transform.rotation *= Quaternion.Euler(GetRandomVector(m_randomRotationValue));
            //m_obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            list.Add(m_obj);
            if (m_movePos)
            {
                if (m_obj.GetComponent<MoveToObject>())
                {
                    MoveToObject m_script = m_obj.GetComponent<MoveToObject>();
                    m_script.m_movePos = m_movePos;
                }
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i]);
        }

        if (list.Count == 0) list.Clear();
    }



}
