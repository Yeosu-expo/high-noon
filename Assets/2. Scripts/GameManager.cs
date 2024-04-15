using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum Identifier { Player, Enemy}
    [Header("#. Game Control")]
    int remainTime;
    public float gameTime;
    public float maxGameTime = 30f;

    public bool isFirstShot = false;
    public Identifier firstHitter;

    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public Transform playerTransform;
    void Awake()
    {
        Instance = this;
        isFirstShot = false;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        remainTime = Mathf.FloorToInt((maxGameTime - gameTime / 60));

        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
            //RoundEnd();
        }
    }

    
}
