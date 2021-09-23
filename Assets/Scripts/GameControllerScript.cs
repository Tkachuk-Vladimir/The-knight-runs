using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance;
    public Text scoreText;
   // public GameObject Environment, Mountain, Rock, Coin, PlayButton,ReloadButton;
    public GameObject Environment, Mountain, Rock, Coin, Menu, ExitButton;
    public bool gameOver;

    float EnvironmentHorizontalLenght, MountainHorizontalLenght;

    private BoxCollider2D EnvironmentCollider, MountainCollider;
    private int score = 0;
    
    Vector2 EnvironmentOffSet, MountainOffSet;

    [SerializeField] float timer; // переменная таймер
    [SerializeField] float timerCoin; // переменная таймер
    [SerializeField] int randomTimeRock;
    [SerializeField] int randomTimeCoin;


    void Awake() // checking working code GameControllerScript
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        // в начале игра остановлена
        gameOver = true;

        // Устанавливаю стартовые значения  
        randomTimeRock = 3;
        randomTimeCoin = 10;

        scoreText.text = "Score: " + score.ToString(); // выводим очки на экран, пользуемся ui текстом

        // Создание клонов Mountain and Environment
        EnvironmentCollider = Environment.GetComponent<BoxCollider2D>(); // получаем доступ к BoxCollider2D
        EnvironmentHorizontalLenght = EnvironmentCollider.size.x; // находим длину  BoxCollider2D
        EnvironmentOffSet = new Vector2(EnvironmentHorizontalLenght, Environment.transform.position.y);
        Instantiate(Environment, EnvironmentOffSet, Quaternion.identity);

        MountainCollider = Mountain.GetComponent<BoxCollider2D>(); // получаем доступ к BoxCollider2D
        MountainHorizontalLenght = MountainCollider.size.x; // находим длину  BoxCollider2D
        MountainOffSet = new Vector2(MountainHorizontalLenght, Mountain.transform.position.y);
        Instantiate(Mountain, MountainOffSet, Quaternion.identity);
    }

    
    void FixedUpdate()
    {
        /*
        if (gameOver == true && Input.GetMouseButtonDown(0))//(Input.GetMouseButtonDown(0)) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// перезагружает активный текущий уровень(scene)  
        }
        else
        {
            InstantiateRocks();
            InstantiateCoins();
        }
        */
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            InstantiateRocks();
            InstantiateCoins();
        }
    }
    
    void InstantiateRocks()
    {
        if (gameOver == true)// проверка жива ли птичка
        {
            return;
        }

        timer += Time.deltaTime; // делаем таймер
       
        if (timer >= randomTimeRock)
        {
            Instantiate(Rock, new Vector2(10f, -1.5f), Quaternion.identity);
            timer = 0f;// reset timer;
            randomTimeRock = Random.Range(1, 5);
        }
    }

    void InstantiateCoins()
    {
        if (gameOver == true)// проверка жива ли птичка
        {
            return;
        }
        timerCoin += Time.deltaTime; // делаем таймер

        if (timerCoin >= randomTimeCoin)
        {
            Instantiate(Coin, new Vector2(10f, 0f), Quaternion.identity);
            timerCoin = 0f;
            randomTimeCoin = Random.Range(5, 10);
        }
    }

    public void GameOver()
    {
        gameOver = true;

        // активируем меню
        Menu.SetActive(true);

        // выключаем клавишу Play
        Menu.transform.GetChild(2).gameObject.SetActive(false);

        // включаем клавишу Reload
        Menu.transform.GetChild(3).gameObject.SetActive(true);

        // включаем клавишу ExitButton
        ExitButton.SetActive(true);
        

        // прячем кнопку play
        // PlayButton.SetActive(false);

        // включаем кнопку reload
        //ReloadButton.SetActive(true);
    }

    public void ScoreCoin()
    {
        if (gameOver == true)// проверка жива ли knigh
        {
            return;
        }
        score++; // add 1 score 
        scoreText.text = "Score: " + score.ToString(); // выводим очки на экран, пользуемся ui текстом
    }

    public void StartGame()
    {
        // включаем игру
        gameOver = false;

        // выключаем меню
        Menu.SetActive(false);

        ExitButton.SetActive(false);


        // прячем кнопку play
       // PlayButton.SetActive(false);

        // прячем кнопку reload
       // ReloadButton.SetActive(false);
    }

    public void ReloadGame()
    {
        // включается заставка
        //BlackImage.SetActive(true);

        // Перезагрузка сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void ExitGame()
    {
       Application.Quit();
    }
}
