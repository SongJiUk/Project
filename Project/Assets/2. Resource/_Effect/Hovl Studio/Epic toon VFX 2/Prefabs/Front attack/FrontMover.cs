using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMover : MonoBehaviour 
{
    public Transform pivot;
    public ParticleSystem effect;
    public float speed = 15f;
    public float drug = 1f;
    public float repeatingTime = 1f;

    private float startSpeed = 0f;
    bool isStart;

    private void Awake()
    {
        effect.Stop();
    }
    void Start()
    {
       
        startSpeed = speed;
    }

    private void OnEnable()
    {
        StartAgain();
    }

    private void OnDisable()
    {
        isStart = false;
    }

    void StartAgain()
    {
        startSpeed = speed;
        transform.position = pivot.position;
        isStart = true;
    }

    void Update()
    {
        if(isStart)
        {
            startSpeed = startSpeed * drug;
            transform.position += transform.forward * (startSpeed * Time.deltaTime);
        }
        
    }
}
