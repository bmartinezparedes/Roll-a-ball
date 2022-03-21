using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerControlled : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI txtContador;
    private GameObject txtGanarObject;
    public GameObject prefab;
    
    private Rigidbody rb;
    private int contador;
    private float movementX,movementY;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var positionX = 2f;
        var positionZ = 2f;
        var radio = 3;
        var cantidad = 5;
        for (int i = 0; i < cantidad; i++)
        {
            double angulo = (Math.PI * 2) / cantidad * i;
            positionX = Convert.ToSingle(radio * Math.Sin(angulo));
            positionZ = Convert.ToSingle(radio * Math.Cos(angulo));
            Instantiate(prefab, new Vector3(positionX, 1, positionZ), Quaternion.identity);
        }

        rb = GetComponent<Rigidbody>();
        contador = 0;
        SetTxtContador();
        // Con GameObject.Find() te busca el objeto por id o tag que le pongas
        txtGanarObject = GameObject.Find("TxtGanar");
        txtGanarObject.SetActive(false);
        
        
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        
    }

    void SetTxtContador()
    {
        txtContador.text = "Contador: " + contador.ToString();
        if (contador >= 8)
        {
            txtGanarObject.SetActive(true);
        }
    }
    //La diferencia entre Update y FixedUpdate
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
    }

    private void Update()
    {
        if (GameObject.Find("Player").transform.position == GameObject.Find("Enemy").transform.position+GameObject.Find("Player").transform.position)
        {
            GameObject.Find("Player").transform.position = new Vector3(0, 0.0f, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            contador += 1;
            SetTxtContador();
        }
        
    }
}
