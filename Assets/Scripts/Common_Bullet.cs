﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Bullet : MonoBehaviour
// Script for base bullet
{
    public int atk;
    public int target; // 0 = Enemy; 1 = Player
    public float linearVelocity;
    public double shootDegree;
    public Vector2 presetVelocity;
    public bool isPiercing;
    public bool needToRotate;
    public bool hasPresetVelocity;

    Rigidbody2D bullet;
    Common_HP targetHP;
    bool outOfScreen = false;


    // String array for checking target tag
    string[] targetList = { "Enemy", "Player" };

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        if (needToRotate)
        {
            bullet.transform.Rotate(new Vector3(0, 0, Convert.ToSingle(shootDegree) - 90.0f));
        }
        if (!hasPresetVelocity)
        {
            bullet.velocity = getVelocity();
        }
        else
        {
            bullet.velocity = presetVelocity;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7.6 || transform.position.x < -7.6 || transform.position.y >5 || transform.position.y < -5)
        {
            outOfScreen = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == targetList[target])
        {
            GameObject hitTarget = collision.gameObject;
            targetHP = hitTarget.GetComponent<Common_HP>();
            if (!targetHP.isInvicible)
            {
                targetHP.damage(atk);
            }
            if (!isPiercing)
            {
                Destroy(gameObject);
            }

        }
    }

    public Vector2 getVelocity()
    {
        return new Vector2(
            linearVelocity * Convert.ToSingle(Math.Cos(Math.PI * shootDegree / 180)),
            linearVelocity * Convert.ToSingle(Math.Sin(Math.PI * shootDegree / 180))
            );
    }

    public bool isOutOfScreen()
    {
        return outOfScreen;
    }
}
