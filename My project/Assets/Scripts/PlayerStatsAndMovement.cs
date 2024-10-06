using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    Vector2 m_Position = Vector2.zero;
    float speed = 5f;
    public int maxHealth = 4;
    public bool isActivePlayer = false;
    public int currentHealth = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!isActivePlayer)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
            }
            if (Input.GetKey(KeyCode.W))
            {

                Vector2 movement = new Vector2(0, verticalInput);
                movement.Normalize();
                transform.Translate(movement * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.S))
            {
                Vector2 movement = new Vector2(0, verticalInput);
                movement.Normalize();
                transform.Translate(movement * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Vector2 movement = new Vector2(horizontalInput, 0);
                movement.Normalize();
                transform.Translate(movement * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector2 movement = new Vector2(horizontalInput, 0);
                movement.Normalize();
                transform.Translate(movement * speed * Time.deltaTime);
            }
        }
    }
            
}
