using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{
    public void pausar(){
        Time.timeScale=0f;//Detenemos el tiempo
    }

    public void despausar(){
        Time.timeScale=1f;//Reanudamos el tiempo
    }
}
