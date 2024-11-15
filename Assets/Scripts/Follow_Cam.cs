using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public GameObject Capsule2;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Capsule2.transform.position + new Vector3(0,0,-10);
    }
}
