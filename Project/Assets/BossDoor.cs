using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossDoor : MonoBehaviour
{

    [SerializeField] Camera playerCam;
    [SerializeField] Camera CutSceneCam;

    [SerializeField] GameObject Boss;
    PlayableDirector pd;
    public TimelineAsset[] ta;

    Animator anim;
    [SerializeField] BoxCollider boxCollider;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartBossScene()
    {
        anim.SetTrigger("isOpen");
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Boss.SetActive(true);
            StartBossScene();

        }
    }
}
