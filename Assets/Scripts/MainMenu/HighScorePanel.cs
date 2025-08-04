using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public GameObject highScoreRowPrefab; // Assign in Inspector
    public Transform contentParent;       // Assign the ScrollView/Content GameObject

    private void OnEnable()
    {
        PopulateTable();
    }

    void PopulateTable()
    {
        // Clear existing rows
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        for (int rows = 3; rows <= 7; rows++)
        {
            for (int cards = 3; cards <= 8; cards++)
            {
                string gameCode = $"Gametype_{rows}rows{cards}cards";
                int score = PlayerPrefs.GetInt(gameCode, 0);

                GameObject row = Instantiate(highScoreRowPrefab, contentParent);

                TextMeshProUGUI[] texts = row.GetComponentsInChildren<TextMeshProUGUI>();
                if (texts.Length >= 2)
                {
                    texts[0].text = gameCode.Replace("Gametype_", "");
                    texts[1].text = score.ToString();
                }
            }
        }
    }
}
