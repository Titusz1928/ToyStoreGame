using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridAutoResizer : MonoBehaviour
{
    public int columns = 7;
    public int rows = 5;

    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        ResizeCells();
    }

    void ResizeCells()
    {
        float totalWidth = rectTransform.rect.width;
        float totalHeight = rectTransform.rect.height;

        float cellWidth = totalWidth / columns;
        float cellHeight = totalHeight / rows;

        gridLayout.cellSize = new Vector2(cellWidth, cellHeight);
    }

    void Update()
    {
        // Optional: Uncomment if you want dynamic resizing on window resize
         //ResizeCells();
    }
}

