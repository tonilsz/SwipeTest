using UnityEngine;
using System.Collections;


public class DeckPanelGenerator : MonoBehaviour {

    public GameObject cardSelector;
    public GameObject space;

    public int[] deckCards = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    public int totalCard = 12;
    public int foundCards = 11;

    private int panelHeight;
    private int heightAmount;

    // Use this for initialization
    void Start() {

        if (ValidateData()) {
            panelHeight = CalculateHeight();

            RectTransform parentTransform = transform.parent.GetComponent<RectTransform>();
            if (parentTransform != null) {
                parentTransform.sizeDelta = new Vector2(0, panelHeight);
                ((RectTransform)transform).sizeDelta = new Vector2(0, panelHeight);
            }
            BuildPanel(700);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private bool ValidateData() {
        return true;
    }

    private int CalculateHeight() {

        // The deck selector will be always on panel
        int height = 700;

        // Calculate required card panels
        int cardPanels = foundCards / 4;
        if (foundCards % 4 > 0)
            cardPanels += 1;

        height += cardPanels * 250; // Card panels
        height += 50; // Space 

        return height;
    }

    private void BuildPanel( int heightAmount) {

        // Calculate required card panels
        int cardPanels = foundCards / 4;
        if (foundCards % 4 > 0)
            cardPanels += 1;

        for (int i = 0; i < cardPanels; ++i) {
            GameObject headerModule = Instantiate(cardSelector, Vector3.zero, Quaternion.identity, transform) as GameObject;
            headerModule.transform.localScale = Vector3.one;
            ((RectTransform)headerModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
            ((RectTransform)headerModule.transform).sizeDelta = new Vector2(800, 250);
            Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
            heightAmount += 250;
        }


        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }

}

