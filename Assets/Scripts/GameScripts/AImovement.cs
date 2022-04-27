using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Mirror;
public enum State {
        Sleeping,
        ChasePlayer,
    }
public class AImovement : NetworkBehaviour
{
    private State state;
    [SyncVar]
    private float speed = 150f, nextWaypointDistance = 5f;
    Path path;
    int currentWaypoint = 0;
    bool reachEndOfPath = false;
    Seeker seeker;
    public Rigidbody2D rb;
    Vector3 currentPosition; 
    public GameObject target;
    int PlayerTargetNumber;
    private PlayerListGame playerListGame;

    // - Variables to find the target
    private int PlayerTarget;
    private float DistanceFromTarget;
    private bool IsCloseEnough = false;


    [Server]
    void Start()
    {
        state = State.Sleeping;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
        UpdatePath();
    }
    [Server]
    void UpdatePath() {
        switch (state) {
            default:
            case State.Sleeping:
                if (seeker.IsDone()) {
                    seeker.StartPath(currentPosition, currentPosition, OnPathComplete);
                }
                break;
            case State.ChasePlayer:
                if (seeker.IsDone()) {
                    seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
                    
                }
                break;
        }
    }
    [Server]
    void Update() {
        playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
        currentPosition = transform.position;
        IsClosest();
        // switch (state) {
        //     case State.ChasePlayer:
        //         Vector3 direction2 = target.transform.position - transform.position;
        //         float angle2 = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
        //         rb.rotation = angle2;
        //         break;
        // }
    }
    // [Server]
    // private void FindTarget() {
    //     float targetRange = 10;
    //     for (var i = 0; i < playerListGame.PlayerList.Count; i++) {
    //         if (Vector3.Distance(currentPosition, playerListGame.PlayerList[PlayerTarget].transform.position) < targetRange) {
    //             rb.constraints = RigidbodyConstraints2D.None;
    //             speed = 400;
    //             target = playerListGame.PlayerList[PlayerTarget];
    //             state = State.ChasePlayer;
    //         } else if (Vector3.Distance(currentPosition, playerListGame.PlayerList[PlayerTarget].transform.position) > targetRange){
    //             rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    //             state = State.Sleeping;
    //             speed = 150;
    //         }
    //     }
    // }
    [Server]
    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }
    [Server]
    void FixedUpdate()
    {
        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count) {
            reachEndOfPath = true;
            UpdatePath();
            return;
        } else {
            reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }
    }

    [Server]
    private void IsClosest() {
        DistanceFromTarget = 10;
        IsCloseEnough = false;
        for(int i = 0; i < playerListGame.PlayerList.Count; i++) {
            float distance = Vector2.Distance(currentPosition,  playerListGame.PlayerList[i].transform.position);
            if(DistanceFromTarget > distance) {
                PlayerTarget = i;
                DistanceFromTarget = distance;
                IsCloseEnough = true;
            }
        }
        Debug.Log(IsCloseEnough);
        if(IsCloseEnough) {
            rb.constraints = RigidbodyConstraints2D.None;
            speed = 400;
            target = playerListGame.PlayerList[PlayerTarget];
            state = State.ChasePlayer;
        } else {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            state = State.Sleeping;
            speed = 150;
            
        }

        //Debug.Log("The closest player is player " + PlayerTarget);

    }


}