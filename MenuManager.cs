using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //this is to load the actual game play scene
    public void StartingGame(){
        SceneManager.LoadScene("LarrysBackUp");
    }

    // this is to load the main menu scene specifically from game over screen
    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    // this will quit the game from main menu
    public void Quit(){
        Application.Quit();
    }
}
