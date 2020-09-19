﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public float powerupSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * powerupSpeed);

        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
