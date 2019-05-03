using UnityEngine;

public class SideUp : MonoBehaviour {



    public Logger logger;
    public string dieName;

    float distToGround;
    Rigidbody rb;

    // https://answers.unity.com/questions/8524/dice-animation-and-face-determination.html
    int CalcSideUp() {
        float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
        if (dotFwd > 0.99f) return 5;
        if (dotFwd < -0.99f) return 2;
        float dotRight = Vector3.Dot(transform.right, Vector3.up);
        if (dotRight > 0.99f) return 4;
        if (dotRight < -0.99f) return 3;
        float dotUp = Vector3.Dot(transform.up, Vector3.up);
        if (dotUp > 0.99f) return 6;
        if (dotUp < -0.99f) return 1;
        return 0;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Update() {
        //if(dieName=="Target") Debug.Log(rb.velocity.magnitude);
        //if(dieName == "Target") Debug.Log(IsGrounded() );

        if (IsGrounded() && rb.velocity.magnitude == 0) { // avoids false positives
            int side = CalcSideUp();
            if (side > 0) {
                Logger.Log(side, dieName);
            }
        }

    }
}
