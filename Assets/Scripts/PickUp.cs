using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int shrimp = 0;
    public Text shrimpText;

    void Start()
    {
        
    }

    void Update()
    {
        shrimpText.text = "Shrimp : " + shrimp.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shrimp")
        {
            Destroy(other.gameObject);
            shrimp++;
        }
    }       
}

