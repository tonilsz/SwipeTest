using UnityEngine;
using System;
using System.Collections.Generic;
using System.Configuration;
using WebSocketSharp;
using WebSocketSharp.Net;
using System.Text;
using WebSocketSharp.Server;
using System.Security.Cryptography.X509Certificates;

public class chromeVoiceRecog : MonoBehaviour {

    /// <summary>
    /// recognizedVoices[i] とすると直近 i番目に認識した音声が取得できる。
    /// recognizedVoices[0] は直前に認識した音声になる。
    /// </summary>
    public Queue<String> recognizedVoices = new Queue<String>();

    public class MyService : WebSocketBehavior {

        public Queue<String> savebuffer;

        public MyService(Queue<String> buf) {
            savebuffer = buf;
            base.IgnoreExtensions = true;
        }

        protected override void OnMessage(MessageEventArgs e) {
            savebuffer.Enqueue(e.Data);
            Debug.Log("MyService:Get message:" + e.Data);
        }

        protected override void OnOpen() {
            Debug.Log("MyService:Socket Open");
        }

        protected override void OnError(ErrorEventArgs e) {
            Debug.Log("MyService:Error:"     + e.Message);
            Debug.Log("MyService:Exception:" + e.Exception);
            Debug.Log("hoge"                 + e.Exception.StackTrace);
        }
    }
    private HttpServer httpsv;

    void Awake() {
        var port = 12002;
        var addr = "localhost";
        var fullUrl = addr + ":" + port;
        httpsv = new HttpServer("http://" + fullUrl);
        httpsv.RootPath = "./htmlcontents"; // TODO: まともなパスに書き換える
        string[] fs = System.IO.Directory.GetFiles(@httpsv.RootPath, "*");
        Debug.Log("current path:" + fs[0]);
        httpsv.Log.Level = LogLevel.Trace;
        httpsv.OnGet += (sender, e) => {
            var req = e.Request;
            var res = e.Response;
            var path = req.RawUrl;
            Debug.Log("http request:" + req);
            if (path == "/") path += "index.html";
            var content = httpsv.GetFile(path);
            if (content == null) {
                res.StatusCode = (int) HttpStatusCode.NotFound;
                res.WriteContent(
                    System.Text.Encoding.UTF8.GetBytes(
                    "File Not Found"));
                return;
            }
            if (path.EndsWith(".html")) {
                res.ContentType = "text/html";
                res.ContentEncoding = Encoding.UTF8;
            }
            res.WriteContent(content);
        };
        httpsv.WaitTime = TimeSpan.FromSeconds(2);
        httpsv.AddWebSocketService<MyService>("/MyService",() => {
            var service = new MyService(recognizedVoices);
            return service;
        });
        httpsv.Start();
        Debug.Log("http server started with " + fullUrl);
    }
    void OnApplicationQuit() {
        httpsv.Stop();
        Debug.Log("websocket server exitted");
    }
}
