using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject objectCanvas;
    public GameObject objectSelectLvl;
    public void SelectLvlButton()
    {
        objectCanvas.SetActive(false);
        objectSelectLvl.SetActive(true);
    }

    public void BackButton()
    {
        objectCanvas.SetActive(true);
        objectSelectLvl.SetActive(false);
    }

    public void Level1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SceneManager.LoadScene(2);
    }
}
