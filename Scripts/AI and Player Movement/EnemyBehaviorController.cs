using UnityEngine;
using UnityEngine.AI;
using System.Collections;

//This should be the manager for all enemy behavior
//Behavior_patrol should be the default behavior until they get in range, then they attack (player in range script takes over)
public class EnemyBehaviorController : MonoBehaviour
{
    public float movementSpeed = 5f; //This should be changed because currently the player can outrun the guards
    
    float searchRadius = 5f; //How far will the guards look for the player
    GameObject player;
    bool playerFound;
    Vector3 target;
    Behavior_Patrol patrolBehavior;

    void Start()
    {
        patrolBehavior = gameObject.GetComponent<Behavior_Patrol>(); //Grab Behavior control on game object which includes nav points for that enemy
        patrolBehavior.ManualStart();
        //Debug.Log("Attempting to manually start patrol" + patrolBehavior);

        //OnDrawGizmos();
    }

    // private void OnDrawGizmos()
    // {
    //     // Draw a yellow sphere at the transform's position
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, searchRadius);
    // }

    void Update()
    {
        ScanForPlayer();
        
        if(!playerFound){
            //Check for proximity to player, and if within range, call PlayerInRange and cutoff Behavior patrol
            ScanForPlayer();
        }
        else{
            SeekAndDestroy(player);
        }  
    }

    void ScanForPlayer(){
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("hopefully found player " + player);

        if(player != null){ //Found the player
            if ((Vector3.Distance(player.transform.position, transform.position)) <= searchRadius)
            {
                //Got him in range, attack
                //Debug.Log("Player in range");
                playerFound = true;
            }
        }
    }

    void SeekAndDestroy(GameObject target){
        // Move our position a step closer to the target.
        float step = movementSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(this.transform.position, target.transform.position) < 1f)
        {
            KillPlayer();
        }
    }

    void KillPlayer(){
        Destroy(player);
        patrolBehavior.ManualStart();
        playerFound = false;
        target = Vector3.zero;
    }
}


