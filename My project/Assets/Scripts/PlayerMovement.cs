using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    Vector2 m_Position = Vector2.zero;
    float speed = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector2(m_Position.x, m_Position.y + (speed * Time.deltaTime));

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector2(m_Position.x, m_Position.y - (speed * Time.deltaTime));
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = new Vector2(m_Position.x - (speed * Time.deltaTime), m_Position.y);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = new Vector2(m_Position.x + (speed * Time.deltaTime), m_Position.y);
            }

        }
    }
}
