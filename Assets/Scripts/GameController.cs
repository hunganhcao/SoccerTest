using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> balls;
    [SerializeField] List<GameObject> nets;
    [SerializeField] UIController ui;
    [SerializeField] Transform Player;
    [SerializeField] CameraMovement cam;
    private GameObject ballToShoot;
    private GameObject netToShoot;

    private List<GameObject> ballsAutoShoot;

    private bool isShooting;
    private void Awake()
    {
        ui.KickAct += ShootBall;
        ui.AutoAct += AutoShootBall;
    }
    private void OnEnable()
    {
       
    }
    private void OnDestroy()
    {
        ui.KickAct -= ShootBall;
        ui.AutoAct -= AutoShootBall;
    }
    // Start is called before the first frame update
    void Start()
    {
      
        ballsAutoShoot = new List<GameObject>();
        ballsAutoShoot.AddRange(balls);
        isShooting=false;
    }

    private void CheckDistanceBall(bool isNear)
    {
        if (balls.Count <= 0) return;
        if (isNear)
        {
            float chooseDistance = Vector3.Distance(Player.position, balls[0].transform.position);
            float distance = 0;
            int chooseIndex = 0;
            for (int i = 1; i < balls.Count; i++)
            {
                distance = Vector3.Distance(Player.position, balls[i].transform.position);

                if (distance < chooseDistance)
                {
                    chooseDistance = distance;
                    chooseIndex = i;
                }
                ballToShoot = balls[chooseIndex];
            }
        }
        else
        {
            float chooseDistance = Vector3.Distance(Player.position, ballsAutoShoot[0].transform.position);
            float distance = 0;
            int chooseIndex = 0;
            if (ballsAutoShoot.Count == 1)
            {
                ballToShoot = ballsAutoShoot[chooseIndex];
                return;
            }
            for (int i = 1; i < ballsAutoShoot.Count; i++)
            {
                distance = Vector3.Distance(Player.position, ballsAutoShoot[i].transform.position);

                if (distance > chooseDistance)
                {
                    chooseDistance = distance;
                    chooseIndex = i;
                }
                ballToShoot = ballsAutoShoot[chooseIndex];

            }
        }
            
        
        
    
    }
    private void CheckDistanceNet()
    {
        if(ballToShoot==null) return;
        float firstDistance = Vector3.Distance(ballToShoot.transform.position, nets[0].transform.position);
        float secondDistance = Vector3.Distance(ballToShoot.transform.position, nets[1].transform.position);
        netToShoot=firstDistance>secondDistance? nets[1]:nets[0];
   

    }
    IEnumerator DoShootBall()
    {
        if(ballToShoot==null) { yield return null; }
        isShooting=true;
        Vector3 dir = netToShoot.transform.position - ballToShoot.transform.position;
        ballToShoot.GetComponent<Rigidbody>().AddForce(dir.normalized * 20, ForceMode.Impulse);
        bool isLeft = netToShoot == nets[0]?true:false;
        cam.MoveFollowBall(ballToShoot.transform,isLeft);
        yield return new WaitForSeconds(2f);
       // ballToShoot = null;
        cam.BackFollowPlayer();
        
        isShooting = false;
        
    }
    public void ShootBall()
    {
        if(isShooting) return;
        CheckDistanceBall(true);
        CheckDistanceNet();
       StartCoroutine( DoShootBall());
    }

    public void AutoShootBall()
    {
        if(isShooting) return;
        CheckDistanceBall(false);
        CheckDistanceNet();
        StartCoroutine(DoShootBall());
        ballsAutoShoot.Remove(ballToShoot);
        if (ballsAutoShoot.Count <= 0)
        {
            ballsAutoShoot.AddRange(balls);
        }
    }

}
