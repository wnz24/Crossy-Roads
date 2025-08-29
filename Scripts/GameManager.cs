using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI LiveScore;
    private int score = 0;
    private AudioSource bgmusic;
    public AudioClip gameOverSound;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        bgmusic = GetComponent<AudioSource>();
        bgmusic.Play();
        bgmusic.loop = true;

    }
    private void Update()
    {
        if(bgmusic != null && isGameOver)
        {
            bgmusic.Stop();
        }
    }
    public void Score()
    {
        Debug.Log("Score!");
        score++;
        LiveScore.text = "Score:" + score;
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        StartCoroutine(GameOverScene());
    }

    private IEnumerator GameOverScene()
    {
        isGameOver = true;

        var GroundShif = GetComponent<GroundShift>();
        if (GroundShif != null) GroundShif.enabled = false;
        var GemSpawn = GetComponent<GemSpawn>();
        if (GemSpawn != null) GemSpawn.enabled = false;
        
    
        
            LiveScore.gameObject.SetActive(false);
        

      
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; 

       
        yield return new WaitForSecondsRealtime(1f);

      
        Time.timeScale = 1f;

        
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
        scoreText.text = "Score: " + score;
    }
}
