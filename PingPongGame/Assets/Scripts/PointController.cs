using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public int highScore;
    private int _layerPoint;
    private int _layerLaser;
    

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        _layerLaser = LayerMask.NameToLayer("Laser");
        _layerPoint = LayerMask.NameToLayer("Point");
    }
 

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == _layerPoint)
        {
            score++;
            //scoreText.text = "Score: " + score;
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("highScore", highScore);
            }
        }else if (col.gameObject.layer==_layerLaser)
        {
            //TODO
            //lose
        }
        
    }
}
