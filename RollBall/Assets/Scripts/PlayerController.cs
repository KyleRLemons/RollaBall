using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public TextMeshProUGUI countText;

    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public Slider speedslider;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();




    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            SceneManager.LoadScene("End");
        }
    }
    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if (kb.escapeKey.wasPressedThisFrame)
        {
            //Time.timeScale = 0;
            //Time.timeScale = 1
            Debug.Log("Hello");
        }

    }
    void FixedUpdate()
    {
        speed = speedslider.value;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        
    }

    public void DropDownInput(int val)
    {
        GameObject myplayer = GameObject.FindGameObjectWithTag("Player");


        if (val == 0)
        {
            myplayer.GetComponent<Renderer>().material.color = Color.blue;

        }
        if (val == 1)
        {
            myplayer.GetComponent<Renderer>().material.color = Color.red;

        }
        if (val == 2)
        {
            myplayer.GetComponent<Renderer>().material.color = Color.yellow;

        }
    }
    
}
