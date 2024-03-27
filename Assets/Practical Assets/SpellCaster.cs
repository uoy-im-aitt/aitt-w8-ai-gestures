using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using InteractML;

public class SpellCaster : MonoBehaviour
{
    [SendToIMLGraph]
    public bool mouseHeld = false;

    [PullFromIMLGraph]
    public int spellToCast = 0;
    
    public Color[] spells;
    public float spellMovementSpeed = 20.0f;
    public GameObject spawnPoint;
    public GameObject target;
    public GameObject spellPrefab;

    private int lastSpell = 0;

    void Start()
    {
        Cursor.visible = false;  
    }

    void Update()
    {
        for(int i = 0; i < spells.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                spellToCast = i+1;
            }
            else if(Input.GetKeyUp(KeyCode.Alpha1 + i))
            {
                spellToCast = 0;
            }
        }
     
        if(spellToCast != lastSpell)
        {
            lastSpell = spellToCast;
            CastSpell();
        }

        if(mouseHeld)
        {
            mouseHeld = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            mouseHeld = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            mouseHeld = true;
        }
    }

    void CastSpell()
    {
        if(spellToCast != 0)
        {
            GameObject spellObj = Instantiate(spellPrefab);
            spellObj.transform.position = spawnPoint.transform.position;

            SpellController controller = spellObj.GetComponent<SpellController>();
            controller.Init(target, spellMovementSpeed, spells[spellToCast-1]);
        }
    }
}