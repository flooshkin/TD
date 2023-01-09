﻿using System.Collections;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed;
    public float startSpeed;

    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        
        float pathLength = Vector2.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / startSpeed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
            }
            else
            {
                Destroy(gameObject);

                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;
            }
        }
    }

    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
            sprite.GetComponentInChildren<SpriteRenderer>().color = new Color(0.35f, 0.56f, 1f);
            StartCoroutine(TimeActive(2f));
        }
        if (other.gameObject.tag == "Blizzard")
        {
            GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
            sprite.GetComponentInChildren<SpriteRenderer>().color = new Color(0.35f, 0.56f, 1f);
            StartCoroutine(TimeActive(2f));
        }
    }

    IEnumerator TimeActive(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

}

