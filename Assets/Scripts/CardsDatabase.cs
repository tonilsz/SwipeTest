using UnityEngine;
using System.Collections.Generic;
using System;

    public class CardsDatabase : ScriptableObject {
        public List<Card> commonCards = new List<Card>();
    }

    [Serializable]
    public class Card {
        public int id = -1;
        public string name = "";
        public string description = "";
        public int type = -1;
    }
