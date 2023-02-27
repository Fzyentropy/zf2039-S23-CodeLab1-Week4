using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    public static Rigidbody2D WASDRb;
    public float moveSpeed = 3;

    

    void Start()
    {
        InitializeRigidbody2D();
    }
    

    void Update()
    {
        if(!GameManager.isReading) { WASDController(); }
        
    }
    
    
    // Initialize Rigidbody2D
    
    void InitializeRigidbody2D()
    {
        if (gameObject.GetComponent<Rigidbody2D>() == null) { gameObject.AddComponent<Rigidbody2D>(); }
        WASDRb = gameObject.GetComponent<Rigidbody2D>();
        WASDRb.gravityScale = 0;
        WASDRb.freezeRotation = enabled;
    }

    void WASDController()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { WASDRb.velocity = Vector2.up * moveSpeed; }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { WASDRb.velocity = new Vector2(0, 0); }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { WASDRb.velocity = Vector2.left * moveSpeed; }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { WASDRb.velocity = new Vector2(0, 0); }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { WASDRb.velocity = Vector2.down * moveSpeed; }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { WASDRb.velocity = new Vector2(0, 0); }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { WASDRb.velocity = Vector2.right * moveSpeed; }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) { WASDRb.velocity = new Vector2(0, 0); }

    }
    
    
    
}
