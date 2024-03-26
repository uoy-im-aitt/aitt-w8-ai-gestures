using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private const float DestroyDistance = 0.01f;

    private Vector3 target;
    private float speed;

    void Start()
    {
        Cursor.visible = false;  
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target) < DestroyDistance)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    public void Init(GameObject target, float speed, Color color)
    {
        this.target = target.transform.position;
        this.speed = speed;

        Light spellLight = GetComponentInChildren<Light>();
        spellLight.color = color;

        ParticleSystem.MainModule spellParticles = GetComponentInChildren<ParticleSystem>().main;
        spellParticles.startColor = color;

        TrailRenderer spellTrail = GetComponentInChildren<TrailRenderer>();
        spellTrail.material.SetColor("_EmissionColor", color);
    }
}
