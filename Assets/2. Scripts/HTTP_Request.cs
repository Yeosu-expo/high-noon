using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;
using System;

public class PlayerChunk 
{
    public string id;
    public string dateTime;
    public int score;

    public PlayerChunk(string id, string dateTime, int score)
    {
        this.id = id;
        this.dateTime = dateTime;
        this.score = score;
    }
}

public class HTTP_Request : MonoBehaviour
{
    private HttpClient _client = new HttpClient(); // HttpClient 인스턴스 초기화
    public static HTTP_Request _instance;

    public static HTTP_Request Instance
    {
        get
        {
            if (_instance == null)
            {
                // 싱글톤 인스턴스가 없는 경우 새로운 게임 오브젝트를 생성하고 HTTP_Request 컴포넌트를 추가
                GameObject singletonObject = new GameObject();
                _instance = singletonObject.AddComponent<HTTP_Request>();
                singletonObject.name = typeof(HTTP_Request).ToString() + " (Singleton)";

                // 싱글톤 오브젝트가 씬 전환 시에도 파괴되지 않도록 설정
                DontDestroyOnLoad(singletonObject);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void PostChunkToServer(PlayerChunk chuck, string url)
    {
        var json = JsonUtility.ToJson(chuck);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync(url, content);

    }
}
