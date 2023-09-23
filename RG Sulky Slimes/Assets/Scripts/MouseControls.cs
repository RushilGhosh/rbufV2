using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControls : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Slime")]
    public GameObject slime;
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;
    public Vector3 startPosition;

    [Header("Lives")]
    public LivesManager livesManager;

    // Start is called before the first frame update
    void Start()
    {
        slimeRigidbody = slime.GetComponent<Rigidbody>();
        startPosition = slime.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(livesManager.lives < 0)
        {
            SceneManager.LoadScene(0); 
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.y * 1.5f
            );
            slimeTransform.position = startPosition - launchVector / 400;
            launchVector.Normalize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce);
            livesManager.RemoveLife();

        }

        if (Input.GetMouseButtonDown(1))
        {
            slimeRigidbody.isKinematic = true;
            slimeRigidbody.position = startPosition;
            
        }

    }
}
