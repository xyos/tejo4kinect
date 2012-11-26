private var force = 10;
private var attached: boolean;

var prevVector : Vector3;
var velo : Vector3;
var prevVelo : Vector3;

function Start () {
    attached = true;
}

function OnTriggerExit (other : Collider) {
    
    if(other.name == "Wallbox"){
	    attached = false;
	    Fire();
    }    
}

function Fire () {
rigidbody.GetComponent("ZigFollowHandPoint").enabled = false;
rigidbody.useGravity = true;
	print("Calcular velocidad y direccion");
	rigidbody.isKinematic = false;
    rigidbody.velocity = -velo*force;

}

function FixedUpdate () {

	if(attached){
		//transform.position = Input.mousePosition;
		velo = prevVector - transform.position;
    	prevVector = transform.position;
    	prevVelo = velo;
	}
	
}