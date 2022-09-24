using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //leveller arası geçiş yapmak için, menüden oyuna geçmek için gerekli.

public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("Gameplay"); //sahne adı
    }

    


} //class



























