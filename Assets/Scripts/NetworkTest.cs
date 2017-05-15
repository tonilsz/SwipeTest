using UnityEngine;
using System.Collections;
using WebSocketSharp;

public class NetworkTest : MonoBehaviour {
        private WebSocket ws;
        // Use this for initialization
        void Start() {
            this.ws = new WebSocket("ws://127.0.0.1:1234");
            this.ws.OnOpen += (sender, e) => {
                Debug.Log("Opened");
            };
            ws.OnMessage += (sender, e) =>
            {
                Debug.Log("WebSocket Message Type: " + e.Type + ", Data: " + e.Data);
            };
            this.ws.OnClose += (sender, e) => {
                Debug.Log("Closed");
            };
            this.ws.Connect();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyUp(KeyCode.Space)) {
                Debug.Log("Pressed");
                ws.Send("Test Message");
            }

        }
        void OnDestroy() {
            ws.Close();
            ws = null;
        }
    }