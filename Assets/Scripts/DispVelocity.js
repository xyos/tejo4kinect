var tejovel : TextMesh;

function Start () {

}

function Update () {
	tejovel.text = "Velocidad: "+ rigidbody.velocity +"Met/seg";
}