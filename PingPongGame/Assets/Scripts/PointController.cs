using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int highScore;
    private int _layerPoint;
    private int _layerLaser;
    public ParticleSystem particleEffect;


    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score: " + highScore;
        _layerLaser = LayerMask.NameToLayer("Laser");
        _layerPoint = LayerMask.NameToLayer("Point");
       
    }
 

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == _layerPoint && Time.timeScale!=0)
        {
            // Score!
            score++;
            scoreText.text = "Score: " + score;
            // Call particle effect
            particleEffect.Play();
            // Increase ball speed
            BallController.instance.IncreaseSpeed();
            if (score > highScore)
            {
                // Update high score
                highScore = score;
                PlayerPrefs.SetInt("highScore", highScore);
                highScoreText.text = "High Score: " + highScore;
            }
        }else if (col.gameObject.layer==_layerLaser )
        {
            // Player unsuccessful
            PlayerPrefs.SetInt("highScore", highScore);
            score = 0;
            scoreText.text = "Score: ";
            GameController.instance.GameOver();
        }
        
    }
}
