using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Delivery : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float rotateSpeed = 0.1f;
    public bool pickedUp = false;
    [SerializeField] Color32 PackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;
    float relativeTime;
    bool slowSpeedOn;
    bool boostSpeedOn;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnCollisionEnter2D(Collision2D Delivery)
    {
        Debug.Log("Collided with something..");
        
    }

    public void OnTriggerEnter2D(Collider2D Delivery)
    {

        if (Delivery.tag == "Package" && !pickedUp)
        {

            Debug.Log("Package Picked Up.");
            Destroy(Delivery.gameObject);
            spriteRenderer.color = PackageColor;
            pickedUp = true;


        }

        if (Delivery.tag == "Drop")
        {
            if (pickedUp == true)
            {

                Debug.Log("Package Successfully Dropped.");
                pickedUp = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("Pick up the Package first!");
            }
        }

        if (Delivery.tag == "Rock")
        {
            Debug.Log("Slowing speed Cabron!");
            slowSpeedOn = true;
            boostSpeedOn = false;
            relativeTime = Time.fixedTime + 2.0f;
        }

        if (Delivery.tag == "PowerUp")
        {
            Debug.Log("Boooooosting!");
            relativeTime = Time.fixedTime + 5.0f;
            boostSpeedOn = true;
            slowSpeedOn = false;
            Destroy(Delivery.gameObject, 0.5f);
        }

        if (Delivery.tag == "Tree")
        {
            Debug.Log("Slowing speed Cabron!");
            slowSpeedOn = true;
            boostSpeedOn = false;
            relativeTime = Time.fixedTime + 2.0f;
        }

    }
void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if (relativeTime >= Time.fixedTime && slowSpeedOn)
        {
            moveSpeed = slowSpeed;
        }
        if (relativeTime >= Time.fixedTime && boostSpeedOn)
        {
            moveSpeed = boostSpeed;
        }
        if (relativeTime < Time.fixedTime)
        {
            moveSpeed = 12f;
            slowSpeedOn = false;
            boostSpeedOn = false;
        }
    }
}
