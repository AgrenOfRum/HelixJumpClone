using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    public GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    
    void OnCollisionEnter(Collision other)
    {
        rb.velocity=Vector3.up * jumpForce;

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("mat:" + materialName);

        if (materialName == "Danger (Instance)")
        {
            gm.GameOver();
        }
        else if (materialName == "Finish (Instance)")
        {
            Debug.Log("finish");
        }
        

        
    }
}
