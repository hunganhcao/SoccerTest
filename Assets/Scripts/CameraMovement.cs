using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Transform MovementTarget;
    private Vector3 offset;
    private Vector3 offsetBall;
    private bool isFollowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isFollowPlayer = true;
        offset= transform.position-Player.position;
        offsetBall = new Vector3(-5, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowPlayer)
        {
            transform.position = Player.position + offset;

        }
        else
        {
            transform.position = MovementTarget.position + offsetBall;
        }
    }
    //coroutine anim ??
    public void MoveFollowBall(Transform target, bool left)
    {   
        offsetBall.x = left ? offsetBall.x :-offsetBall.x;
        transform.position= target.position+offsetBall;
        isFollowPlayer=false;
        MovementTarget = target;
        transform.LookAt(target.position);
    }
    public void BackFollowPlayer() { 
        transform.position= Player.position-offset;
        isFollowPlayer=true; 
        MovementTarget = null;
        transform.eulerAngles=new Vector3(90,0,0);
        
    }
}
