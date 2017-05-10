using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private CardsDatabase cardsDB;

	// Use this for initialization
	void Start () {
        cardsDB = new CardsDatabase();


        //cardsDB = JsonUtility.FromJson<CardsDatabase>(json);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void SaveState() {

        //string json = JsonUtility.ToJson(myObject);
    }
}
