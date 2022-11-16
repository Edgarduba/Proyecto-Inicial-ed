using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int vidas = 3;
    public int puntos = 0;
    public AudioClip bomba;

    void Awake() 
    {
        //si ya hay una instancia y no soy yo me destruyo
        if(Instance !=null && Instance != this)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(this);
    }

    public void RestarVidas()
    {
        vidas--;
    }
}
