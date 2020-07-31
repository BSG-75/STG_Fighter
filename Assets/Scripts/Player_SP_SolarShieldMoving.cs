﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldMoving : MonoBehaviour
{
    Rigidbody2D solarShield;
    public float sensitivity;
    float size = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        solarShield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
    {
        Vector2 mouse = new Vector2(
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -7.1f, 7.1f),
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4.1f, 4.1f)
            );
        solarShield.velocity = sensitivity * (mouse - (Vector2)transform.position);
        if (size < 4)
        {
            size += 4 * Time.fixedDeltaTime;
            transform.localScale = new Vector3(size, size, 1);
        }
    }
}
