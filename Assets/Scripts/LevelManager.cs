using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

















    //"в фумі починається істерика* він поченає плакати і наспівувати да по далі все пішло паболело і 
    // прашло хто разкажет про любов в якій ховається тепло ФУМЯ ПЕРЕСТАНЬ РІЗАТИ ВЕНИ де образи а де біль 
    // все саме пройде без зусиль ФУМЯ ЗУПИНИСЬ!!!!!!!!!! як на рану сипать сіль *курай підходить до фумі 
    // щоб забрати ніж але...* CAPCUT Введите текст
}
