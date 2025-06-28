using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public Text healthText;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
        }
        else if (other.gameObject.tag == "GoldShrimp")
        {
            audioSource.Play();
            health++;
            Destroy(other.gameObject);
        }
    }
}
