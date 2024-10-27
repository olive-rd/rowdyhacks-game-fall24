using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle obstacle;
    private GameObject player;
    private PlayerController playerController;
    public SpriteRenderer spriteRenderer;
    private Transform playerCarTransform;
    public GameData gameData;
    private Movement movement;
    private void Start()
    {
        StartObstacle();
        movement = player.GetComponent<Movement>();
        playerCarTransform = player.transform;
    }

    private void Update()
    {
        if (playerCarTransform == null) return;
        if (Mathf.Abs(transform.position.x - playerCarTransform.position.x) >= 200)
        {
            Destroy(gameObject);
            return;
        }
    }

    void StartObstacle()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetSprite();
        movement = player.GetComponent<Movement>();
        playerController = player.GetComponent<PlayerController>();
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
    }

    void SetSprite()
    {
        if(gameData.boostActive)
            spriteRenderer.sprite = obstacle.futureSprite;
        else
            spriteRenderer.sprite = obstacle.normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(("Player")))
        {
            Debug.Log("hit");
            if (movement.curSpeed - (movement.maxSpeed * .7f) <= 0)
            {
                Debug.Log(movement.curSpeed);
                HitObstacleDeath();
            }
            else
            {
                HitObstacle();
            }
            
        }
    }
    void HitObstacle()
    {
        Debug.Log(obstacle.obstacleType);
        switch (obstacle.obstacleType)
        {
            case Obstacle.ObstacleType.Slow:
                playerController.StartSlowed();
                break;
            case Obstacle.ObstacleType.Spin:
                playerController.StartSpin();
                Destroy(this.gameObject);
                break;
        }
    }

    void HitObstacleDeath()
    {
        Debug.Log("Death");
    }
}
