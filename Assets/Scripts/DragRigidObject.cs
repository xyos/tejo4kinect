using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class DragRigidObject : MonoBehaviour
{

    public static DragRigidObject Instance;
    public int normalCollisionCount = 1;
    public float moveLimit = .5f;
    public float collisionMoveFactor = .01f;
    public float addHeightWhenClicked = 0.0f;
    public bool freezeRotationOnDrag = true;
    public Camera cam;
    private Rigidbody myRigedbody;
    private Transform myTransform;
    public bool canMove = false;
    private float yPos;
    private bool gravitySetting;
    private bool freezeRotationSetting;
    private float sqrMoveLimit;
    private int collisionCount = 0;
    private Transform camTransform;

    //private

    private float mouseStartY;
    public float zOffset;

    void Start () {
       Instance = this;
       myRigedbody = rigidbody;
       myTransform = transform;
       if(!cam)
         cam = Camera.main;

       if(!cam){
         Debug.LogError("Can't find camera tagged MainCamera");
         return;
       }

       camTransform = cam.transform;
       sqrMoveLimit = moveLimit * moveLimit;
    }


    public void Lift () {
       Debug.Log("LIFT");
       canMove = true;
       myTransform.Translate(Vector3.up * addHeightWhenClicked);
       gravitySetting = myRigedbody.useGravity;
       freezeRotationSetting = myRigedbody.freezeRotation;
       myRigedbody.useGravity = false;
       myRigedbody.freezeRotation = freezeRotationOnDrag;
       yPos = myTransform.position.y;
       mouseStartY = Input.mousePosition.y;
    }

    public void Release ()  {
       canMove = false;
       myRigedbody.useGravity = gravitySetting;
       myRigedbody.freezeRotation = freezeRotationSetting;
       if (!myRigedbody.useGravity)
         myTransform.position = new Vector3(myTransform.position.x, yPos - addHeightWhenClicked, myTransform.position.z);
    }  

    void OnCollisionStay (Collision collision) {
       Debug.Log("OnCollisionEnter");
       collisionCount++; 

       HandleCollision(collision);
    }

    void HandleCollision(Collision collision)
    {
       if(canMove){
         float y_pos = 0;
         for(int n = 0; n < collision.contacts.Length; n++){
          ContactPoint contact = collision.contacts[n];
          Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
          Vector3 pos = contact.point;
          float temp_y = contact.otherCollider.bounds.size.y + contact.otherCollider.transform.position.y;
          if(temp_y > y_pos) y_pos = temp_y;
         }
         if((y_pos + addHeightWhenClicked) > yPos) 
          yPos = y_pos + addHeightWhenClicked;


         //Instantiate(explosionPrefab, pos, rot) as Transform;

       }
    }

    void OnCollisionExit (Collision collision) {
       Debug.Log("OnCollisionExit");
       collisionCount--; 
       //HandleCollision(collision, false);
    }

    // Update is called once per frame
    void FixedUpdate () {

       Vector3 mousePos = Input.mousePosition;
       Ray ray = cam.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;

       int layerMask = 1 << 8;
       layerMask = ~layerMask;
       if(Physics.Raycast(ray, out hit, Mathf.Infinity ,layerMask)){
         Debug.DrawLine(ray.origin, hit.point, Color.yellow); 
         Debug.Log(hit.point);
       }

       if (!canMove) return;

       myRigedbody.velocity = Vector3.zero;
       myRigedbody.angularVelocity = Vector3.zero;
       myTransform.position = new Vector3(myTransform.position.x, yPos, myTransform.position.z);



       //if our hit.point is not null then set our z position to hit.point.z
       Debug.Log(hit.point.z);
       Vector3 move = cam.ScreenToWorldPoint(new Vector3(mousePos.x, 0, hit.point.z)) - myTransform.position;
       move.y = 0.0f;


       if (collisionCount > normalCollisionCount) {
            move = move.normalized*collisionMoveFactor;
        }
        else if (move.sqrMagnitude > sqrMoveLimit) {
            move = move.normalized*moveLimit;
        }



        myRigedbody.MovePosition(myRigedbody.position + move);
       myRigedbody.position = new Vector3(myRigedbody.position.x, myRigedbody.position.y, hit.point.z);
    }
}