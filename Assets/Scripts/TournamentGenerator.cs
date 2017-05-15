using UnityEngine;
using System.Collections;

public class TournamentGenerator : MonoBehaviour {
    
    public GameObject space;
    public GameObject tittle;
    public GameObject specialPanel;
    public GameObject cammonPanel;

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
            BuildPanel();
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private bool ValidateData() {
        return true;
    }

    private int CalculateHeight() {

        int height = 0;
        height += 2 * 100; // Tittles
        height += 2 * 50; // Space
        height += 1 * 250; // Special 
        height += 2 * 200; // Cammon 

        return height;
    }

    private void BuildPanel() {

        BuildSpecialTournament();
        BuildCammonTournament();

    }

    private void BuildSpecialTournament() {

        GameObject separatorModule = Instantiate(tittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        separatorModule.transform.localScale = Vector3.one;
        ((RectTransform)separatorModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)separatorModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 100;

        GameObject CardModule = Instantiate(specialPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 250);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 250;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }

    private void BuildCammonTournament() {

        GameObject separatorModule = Instantiate(tittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        separatorModule.transform.localScale = Vector3.one;
        ((RectTransform)separatorModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)separatorModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 100;

        GameObject CardModule = Instantiate(cammonPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 200);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 200;

        CardModule = Instantiate(cammonPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 200);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 200;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }
}
