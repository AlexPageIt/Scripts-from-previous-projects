#pragma strict
 var Player : Transform;
 var MoveSpeed = 2;
 var MaxDist = 20;
 var MinDist = 5;
 
 function Start () 
 {
 }
 
 function Update () 
 {
 	// Get player position
 	var point: Vector3 = Player.position;
 	// Set z position to 0, since the game is in 2D
 	point.z = 0.0;
 	// Make enemy focus on the player position
    transform.LookAt(point);
    
    // Make the enemy face the player
    if (Player.position.x < transform.position.x)
    	transform.rotation = Quaternion.Euler(0.0, 180.0, 0.0);
    if (Player.position.x > transform.position.x)
    	transform.rotation = Quaternion.Euler(0.0, 0.0, 0.0);
     
     // If the player's distance to the enemy is less than maximum distance enemy will attack
     if(Vector3.Distance(transform.position,Player.position) <= MaxDist){
     	// Enemy moves towards player
        transform.position += transform.right*MoveSpeed*Time.deltaTime;    
          
        // Enemy will stop if it is within the minimum distance of the player
        if(Vector3.Distance(transform.position,Player.position) <= MinDist)
        {
         	var MoveSpeed = 0; 
        }  
    }
 }