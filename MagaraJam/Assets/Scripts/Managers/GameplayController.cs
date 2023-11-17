using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum EnemyGoal
{
    PLAYER,
    FENCE
}

public enum GameGoal
{
    KILL_ENEMY,
    WALK_TO_GOAL_STEPS,
    DEFEND_FENCE,
    TIMER_COUNTDOWN,
    GAME_OVER
}

public class GameplayController : MonoBehaviour
{
    [Header("Elements")]
    public static GameplayController instance;

    [HideInInspector]
    public bool bullet_And_BulletFX_Created, rocket_Bullet_Created;

    [HideInInspector]
    public bool PlayerAlive, FenceDestroyed;

    private Transform _playerTarget;
    private Vector3 _player_Previous_Position;
    private int _initial_Step_Count;

    public EnemyGoal EnemyGoal = EnemyGoal.PLAYER;
    public GameGoal gameGoal = GameGoal.WALK_TO_GOAL_STEPS;

    public Text EnemyCounter_Text, Timer_Text, StepCounter_Text;
    public Image PlayerLife;

    [Header("Settings")]
    public int Enemy_Count = 20;
    public int timer_Count = 100;

   
   

    public int Step_Count = 100;
    

   
    [HideInInspector]
    public int CoinCount;

    public GameObject PausePanel, GameOverPanel;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        PlayerAlive = true;

        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {

            _playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
            _player_Previous_Position = _playerTarget.position;
            _initial_Step_Count = Step_Count;
            StepCounter_Text.text = Step_Count.ToString();

        }

        if (gameGoal == GameGoal.TIMER_COUNTDOWN || gameGoal == GameGoal.DEFEND_FENCE)
        {

            Timer_Text = GameObject.Find("Timer Counter").GetComponent<Text>();
            Timer_Text.text = timer_Count.ToString();

            InvokeRepeating("TimerCountdown", 0f, 1f);

        }

        if (gameGoal == GameGoal.KILL_ENEMY)
        {
            EnemyCounter_Text.text = Enemy_Count.ToString();
        }

    }

    void OnDisable()
    {
        instance = null;
    }

    void Update()
    {

        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            CountPlayerMovement();
        }

    }

    void CountPlayerMovement()
    {

        Vector3 playerCurrentMovement = _playerTarget.position;

        float dist = Vector3.Distance(new Vector3(playerCurrentMovement.x, 0f, 0f),
                                      new Vector3(_player_Previous_Position.x, 0f, 0f));

        // player moving forward
        if (playerCurrentMovement.x > _player_Previous_Position.x)
        {

            if (dist > 1)
            {

                Step_Count--;

                if (Step_Count <= 0)
                {
                    GameOver();
                }

                _player_Previous_Position = _playerTarget.position;

            }

            // player moving backwards
        }
        else if (playerCurrentMovement.x < _player_Previous_Position.x)
        {

            if (dist > 0.8f)
            {

                Step_Count++;

                if (Step_Count >= _initial_Step_Count)
                {
                    Step_Count = _initial_Step_Count;
                }

                _player_Previous_Position = _playerTarget.position;

            }

        }

        StepCounter_Text.text = Step_Count.ToString();

    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void TimerCountdown()
    {

        timer_Count--;

        Timer_Text.text = timer_Count.ToString();

        if (timer_Count <= 0)
        {
            CancelInvoke("TimerCountdown");
            GameOver();
        }

    }

    public void ZombieDied()
    {
        Enemy_Count--;
        EnemyCounter_Text.text = Enemy_Count.ToString();

        if (Enemy_Count <= 0)
        {
            GameOver();
        }

    }

    public void PlayerLifeCounter(float fillPercentage)
    {
        fillPercentage /= 100f;

        PlayerLife.fillAmount = fillPercentage;
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_NAME);
    }

} // class
