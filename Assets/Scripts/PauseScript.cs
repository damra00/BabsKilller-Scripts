using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool PauseGame;
    public GameObject PauseMenuu,Character;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    public void Pause()
    {
        PauseMenuu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
        Character.GetComponent<CharacterControll>().rg.isKinematic = true;
    }
    public void Resume()
    {
        PauseMenuu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        Character.GetComponent<CharacterControll>().rg.isKinematic = false;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
