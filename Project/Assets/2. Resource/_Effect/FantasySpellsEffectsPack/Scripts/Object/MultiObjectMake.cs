using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectMake : _ObjectMakeBase
{

    public float m_startDelay;
    public int m_makeCount;
    public float m_makeDelay;
    public Vector3 m_randomPos;
    public Vector3 m_randomRot;
    float m_Time;
    float m_Time2;
    float m_delayTime;
    float m_count;
    List<GameObject> list = new List<GameObject>();

    bool isEnable = false;

    private void OnEnable()
    {
        isEnable = true;
        m_Time = m_Time2 = Time.time;

    }

    private void OnDisable()
    {
        isEnable = false;

        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i]);
        }

        if (list.Count == 0) list.Clear();
        m_count = 0;
    }



    void Update()
    {
        if (isEnable)
        {
            if (Time.time > m_Time + m_startDelay)
            {
                if (Time.time > m_Time2 + m_makeDelay && m_count < m_makeCount)
                {
                    Vector3 m_pos = transform.position + GetRandomVector(m_randomPos);
                    Quaternion m_rot = transform.rotation * Quaternion.Euler(GetRandomVector(m_randomRot));

                    for (int i = 0; i < m_makeObjs.Length; i++)
                    {
                        GameObject m_obj = Instantiate(m_makeObjs[i], m_pos, m_rot);
                        m_obj.transform.parent = this.transform;
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

                    m_Time2 = Time.time;
                    m_count++;
                }
            }
        }

    }
}
