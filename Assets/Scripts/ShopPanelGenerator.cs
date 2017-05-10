using UnityEngine;
using System.Collections;



public class ShopPanelGenerator : MonoBehaviour {

    public GameObject header;
    public GameObject separator;
    public GameObject space;
    public GameObject tittle;
    public GameObject subtittle;
    public GameObject cardPanel;

    public int[] cardsToSell = { 0, 1, 2 };

    public int[] chestsToSell = { 0, 1, 2 };

    public int[] gemsPacks = { 0, 1, 2, 3, 4, 5 };

    public int[] coinsPacks = { 0, 1, 2 };

    private int panelHeight;
    private int heightAmount;

    // Use this for initialization
    void Start () {

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
	void Update () {
	
	}

    private bool ValidateData() {
        return true;
    }

    private int CalculateHeight() {

        int height = 0;
        height += 350; // Header
        height += 2 * 50; // Separator
        height += 3 * 50; // Tittle 
        height += 1 * 50; // Subtittle 
        height += 4 * 50; // Space 
        height += 5 * 400; // ButtonPanel 

        return height;
    }

    private void BuildPanel() {

        heightAmount = 0;
        GameObject headerModule = Instantiate(header, Vector3.zero, Quaternion.identity, transform) as GameObject;
        headerModule.transform.localScale = Vector3.one;
        ((RectTransform)headerModule.transform).anchoredPosition = new Vector2(0, heightAmount);
        ((RectTransform)headerModule.transform).sizeDelta = new Vector2(800, 350);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 350;

        BuildCardShop();
        BuildChestsShop();
        BuildGemsShop();
        BuildCoinsShop();

    }

    private void BuildCardShop() {

        GameObject separatorModule = Instantiate(separator, Vector3.zero, Quaternion.identity, transform) as GameObject;
        separatorModule.transform.localScale = Vector3.one;
        ((RectTransform)separatorModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)separatorModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject CardModule = Instantiate(cardPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 400);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 400;

        separatorModule = Instantiate(separator, Vector3.zero, Quaternion.identity, transform) as GameObject;
        separatorModule.transform.localScale = Vector3.one;
        ((RectTransform)separatorModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)separatorModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }

    private void BuildChestsShop() {

        GameObject tittleModule = Instantiate(tittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        tittleModule.transform.localScale = Vector3.one;
        ((RectTransform)tittleModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)tittleModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject subtittleModule = Instantiate(subtittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        subtittleModule.transform.localScale = Vector3.one;
        ((RectTransform)subtittleModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)subtittleModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject CardModule = Instantiate(cardPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 400);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 400;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }

    private void BuildGemsShop() {

        GameObject tittleModule = Instantiate(tittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        tittleModule.transform.localScale = Vector3.one;
        ((RectTransform)tittleModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)tittleModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject CardModule = Instantiate(cardPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 400);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 400;

        CardModule = Instantiate(cardPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 400);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 400;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }

    private void BuildCoinsShop() {

        GameObject tittleModule = Instantiate(tittle, Vector3.zero, Quaternion.identity, transform) as GameObject;
        tittleModule.transform.localScale = Vector3.one;
        ((RectTransform)tittleModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)tittleModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

        GameObject CardModule = Instantiate(cardPanel, Vector3.zero, Quaternion.identity, transform) as GameObject;
        CardModule.transform.localScale = Vector3.one;
        ((RectTransform)CardModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)CardModule.transform).sizeDelta = new Vector2(800, 400);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 400;

        GameObject spaceModule = Instantiate(space, Vector3.zero, Quaternion.identity, transform) as GameObject;
        spaceModule.transform.localScale = Vector3.one;
        ((RectTransform)spaceModule.transform).anchoredPosition = new Vector2(0, -heightAmount);
        ((RectTransform)spaceModule.transform).sizeDelta = new Vector2(800, 50);
        Debug.Log("ph: " + panelHeight + "ha: " + heightAmount);
        heightAmount += 50;

    }






}
