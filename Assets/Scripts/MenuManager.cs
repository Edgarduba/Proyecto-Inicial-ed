using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject title;
    public GameObject mainButtons;
    public GameObject optionsMenu;
    public string Platforms;

    public void OpenOptions ()
    {
        title.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void PlayButton ()
    {
        SceneManager.LoadScene("Platforms");
    }
}
