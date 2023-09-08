using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    public Slider Hpbar;
    public Slider FollowHpbar;
    public bool FollowHppHit = false;

    public float maxHp = 1000f;
    public float currentHp = 1000f;

    [SerializeField] Transform enemy;
    [SerializeField] Camera camera;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"{camera.WorldToScreenPoint(cube.position)}");
        if (Hpbar != null)
        {
            Hpbar.transform.position = camera.WorldToScreenPoint(enemy.position);
            Hpbar.value = Mathf.Lerp(Hpbar.value, currentHp / maxHp, Time.deltaTime * 5f);
            if (FollowHppHit)
            {
                FollowHpbar.value = Mathf.Lerp(FollowHpbar.value, Hpbar.value, Time.deltaTime * 10f);
                if (Hpbar.value >= FollowHpbar.value - 0.01f)
                {
                    FollowHppHit = false;
                    FollowHpbar.value = Hpbar.value;
                }
            }
            if (Hpbar.value > 0.5f)
            {
                Dmg();
            }
        }
    }

    public void Dmg()
    {
        currentHp -= 10f;
        Invoke("BackHpFun", 0.5f);
    }

    void BackHpFun()
    {
        FollowHppHit = true;
    }
}

