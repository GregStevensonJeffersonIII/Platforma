using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject WinImage;


    private int lives = 3;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this) 
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

    }
    
    IEnumerator WinFade()
    {

        yield return new WaitForSeconds(3f);
        for (float i = 0; i <1.1; i += 0.1f)
        {
            WinImage.GetComponent<Image>().color = new Color(1,1,1, i);
            yield return new WaitForSeconds(0.2f);
        }

    }
    public void DecreaseLives() { 
    lives--;
    }

    public int GetLives() { 
    return lives;
    }

    public void Win() {
        StartCoroutine("WinFade");
    }
}
