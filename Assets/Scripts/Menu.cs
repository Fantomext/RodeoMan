using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;

    [SerializeField] private MonoBehaviour[] _comonentsToDisable;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        
    }
    public void OpenMenuWindow()
    {
        _menuWindow.SetActive(true);
        _menuButton.SetActive(false);
        for (int i = 0; i < _comonentsToDisable.Length; i++)
        {
            _comonentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0.01f;
        Cursor.visible = true;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        for (int i = 0; i < _comonentsToDisable.Length; i++)
        {
            _comonentsToDisable[i].enabled = true;
        }
        Cursor.visible = false;
        Time.timeScale = 0.01f;
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
