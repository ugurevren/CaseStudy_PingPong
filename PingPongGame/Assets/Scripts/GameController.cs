using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject ball;
    public GameObject player;
    public GameObject startingText;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }
    void Start()
    {
        // Stop Game
        Time.timeScale = 0;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Start Game
            startingText.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        // Stop game and reset everything
        BallController.instance.ResetBall();
        ball.transform.position = new Vector3(0, 0.5f, 0);
        player.SetActive(false);
        player.transform.position = new Vector3(-2.5f,0,0);
        player.SetActive(true);
        startingText.SetActive(true);
        Time.timeScale = 0;
    }
}
