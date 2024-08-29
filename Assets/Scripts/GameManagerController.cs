using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private Button[] Buttons;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Reanudar()
    {
        Time.timeScale = 1;
    } 
    public void ButtonsInteracutue(bool a)
    {
        for(int i=0; i<Buttons.Length; i++)
        {
            Buttons[i].interactable = a;
        }
    }
    public void Exit()
    {
        Application.Quit();
        print("Saliste del juego");
    }
}
