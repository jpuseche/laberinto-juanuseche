using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Slider sizeSlider;
    public Text sizetext;
    public Slider obstacleSlider;
    public Text obstacletext;
    public void SetSize()
    {
        sizetext.text = "Board Size: " + (int) ((sizeSlider.value*5)+10);
        PlayerPrefs.SetInt("size", (int)((sizeSlider.value * 5) + 10));
    }
    public void SetObstacles()
    {
        obstacletext.text = "Number of Obstacles: " + (int)(obstacleSlider.value * Mathf.Pow(((sizeSlider.value * 4) + 8), 2));
        PlayerPrefs.SetInt("obstacles", (int)(obstacleSlider.value * Mathf.Pow(((sizeSlider.value * 4) + 8), 2)));
    }
}
