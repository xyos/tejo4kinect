var Tejo : Transform;
var speed = 15;

function Update () {

if ( Input.GetButton ("Fire1")) {

var crate = Instantiate(Tejo,transform.position, Quaternion.identity);
crate.rigidbody.AddForce(transform.forward * 400);




}
}