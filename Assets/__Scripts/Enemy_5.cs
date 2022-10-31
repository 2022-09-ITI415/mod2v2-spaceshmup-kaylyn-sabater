﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy {

    [Header("Set in Inspector: Enemy_5")]
    public float lifeTime = 8;

    [Header("Set Dynamically: Enemy_5")]
    public Vector3[] points;
    public float birthTime;
    
 private void Start()
    {
        points = new Vector3[3]; // Initialize points

        // The start position has already been set by Main.SpawnEnemy()
        points[0] = pos;

        // Set xMin and xMax the same way that Main.SpawnEnemy() does
        float xMin = -bndCheck.camWidth + bndCheck.radius;
        float xMax = bndCheck.camWidth - bndCheck.radius;

        Vector3 v;
        // Pick a random middle position in the bottom half of the screen
        v = Vector3.zero;
        v.x = Random.Range(xMin, xMax);
        v.y = -bndCheck.camHeight * Random.Range(2.75f, 2);
        points[1] = v;

        // Pick a random final position above the top of the screen
        v = Vector3.zero;
        v.y = pos.y;
        v.x = Random.Range(xMin, xMax);
        points[2] = v;

        // Set the birthTime to the current time
        birthTime = Time.time;
    }

    public override void Move()
    {
        // Bezier curves work based on a u value between 0 & 1
        float u = (Time.time - birthTime) / lifeTime;

        if (u > 1)
        {
            // This Enemy_5 has finished its life
            Destroy(this.gameObject);
            return;
        }

    
        Vector3 p01;
        u = u - (0.2f * Mathf.Sin(u * Mathf.PI * 2));
        p01 = ((1 - u) * points[0]) + (u * points[1]);
        pos = ((1 - u) * p01);
    }}