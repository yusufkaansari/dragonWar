using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    public static GameManager Instance { get; private set; }

    public event System.Action<int> OnScoreChanged;
    public event System.Action OnSceneChanged;
    private void Awake()
    {
        SingletonThisGameObject();

    }

    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            // Class'ýn referansý Instance'e atýlýr.
            Instance = this;
            // Bu class'ýn üstünde/içinde olduðu Game Object'i yok etme
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Class'ýn ikinci bir örneði alýnmak istenirse diye;
            Destroy(this.gameObject);
        }
    }

    public void IncreaseScore()
    {
        score += 10;
        /*
        if (OnScoreChanged !=null){
            OnScoreChanged();
        }
        */
        OnScoreChanged?.Invoke(score);
    }

    public void StartGame()
    {
        score = 0;
        Time.timeScale = 1;
        //Coroutine veya Async methodlarý þu durumlarda kullanýlýr. Diðer iþlemleri durdurmadan çalýþýr.
        StartCoroutine(StartGameAsync());
        //SceneManager.LoadScene("Game");
    }

    private IEnumerator StartGameAsync()
    {
        OnSceneChanged?.Invoke();
        yield return SceneManager.LoadSceneAsync("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        StartCoroutine(ReturnMenuAsync());
    }
    private IEnumerator ReturnMenuAsync()
    {
        OnSceneChanged?.Invoke();
        yield return SceneManager.LoadSceneAsync("Menu");
    }


}
