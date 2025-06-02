using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    [SerializeField] public int shrimp = 0;
    public Text shrimpText;
    public GameObject objectToActivate;

    void Update()
    {
        shrimpText.text = shrimp.ToString();

        if (shrimp == 4)
        {
            objectToActivate.SetActive(true);
            Time.timeScale = 0f;
        }
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

