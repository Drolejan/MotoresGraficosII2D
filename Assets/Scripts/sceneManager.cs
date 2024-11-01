using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Cargamos la libreria de manejo de Escenas


public class sceneManager : MonoBehaviour
{
    public void newGame(){
        //Borramos los datos
        PlayerPrefs.DeleteAll();//Borramos nuestra partida guardada
        //Cargamos la escena utilizando su nombre
        SceneManager.LoadScene("SideScroll");
    }

    public void Continue(){
        //Cargamos la escena utilizando su nombre
        SceneManager.LoadScene("SideScroll");
    }
}
