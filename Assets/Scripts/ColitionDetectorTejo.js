var Sound : AudioClip;
function OnCollisionEnter(collision : Collision) {
        // Debug-draw all contact points and normals
    for (var contact : ContactPoint in collision.contacts)
        Debug.DrawRay(contact.point, contact.normal, Color.white);
    
        // Play a sound if the coliding objects had a big impact.        
    if (collision.relativeVelocity.magnitude > 0.1)
         transform.Translate(Vector3(0,0,0));//stop cloned spear moving
         transform.Rotate(Vector3(0,0,0));//stop cloned spear rotating
         rigidbody.useGravity = true; //stop it falling to ground
        // print("este es el tejo");
         audio.PlayOneShot(Sound);
    	rigidbody.GetComponent("ZigFollowHandPoint").enabled = false;
    }
