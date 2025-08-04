using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour
{
    public static NewGameManager Instance;

    public Slider heightSlider;
    public TextMeshProUGUI gameAreaText;
    public TextMeshProUGUI cardNumberText;

    // Maps height -> width
    private Dictionary<int, int> heightToWidth = new Dictionary<int, int>
    {
        { 3, 5 },
        { 4, 6 },
        { 5, 7 },
        { 6, 9 },
        { 7, 12 }
    };

    private void Awake()
    {
        Instance = this;
    }


    public void SetGameArea(float heightFloat)
    {
        int height = Mathf.RoundToInt(heightFloat);

        if (!heightToWidth.TryGetValue(height, out int width))
        {
            //Debug.LogWarning($"Unsupported height value: {height}");
            return;
        }

        GameSettings.GridHeight = height;
        GameSettings.GridWidth = width;

        Debug.Log("gamesettings: " + GameSettings.GridHeight + " " + GameSettings.GridWidth+" "+GameSettings.MaxAllowed);

        gameAreaText.text = $"{height} x {width}";
    }

    public void SetCardNumber(float numberOfCards)
    {
        GameSettings.MaxAllowed = (int)numberOfCards;

        cardNumberText.text = $"{numberOfCards}";
    }
}
