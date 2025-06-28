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
    [SerializeField] private GameObject[] shrimpCount;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shrimpCount = GameObject.FindGameObjectsWithTag("Shrimp");
    }

    void Update()
    {
        shrimpText.text = shrimp.ToString();

        if (shrimp == shrimpCount.Length)
        {
            objectToActivate.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shrimp")
        {
            audioSource.Play();
            Destroy(other.gameObject);
            shrimp++;
        }
    }      
}

