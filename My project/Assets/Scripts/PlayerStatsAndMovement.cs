using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    Vector2 m_Position = Vector2.zero;
    float speed = 5f;
    public int maxHealth = 4;
    public bool isActivePlayer = false;
    public int currentHealth = 4;
    public string name = "";

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.mass = 0f;
        rb.freezeRotation = true;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Debug.Log(box);
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
    public void TakeDamage(){
        currentHealth --;
        if (currentHealth <=0){
            KillPlayer();
        }
    }

    void KillPlayer(){

    }

    public void AllDamage(){
        
    }
            
}
