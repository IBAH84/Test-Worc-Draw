using UnityEngine;
using System.Collections;

public class Menenger : MonoBehaviour {

    public static Menenger instance;

    public int countLevel = 0;
    public float timerStart = 300;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }
    public void Levels()
    {
        countLevel++;
        timerStart -= 40f;
    }
    public void Restart()
    {
        countLevel = 0;
        timerStart = 300f;
    }
}
