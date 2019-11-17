using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    Camera cam;
    bool numberEight = true;
    bool numberThree = true;
    bool numberFour = true;
    bool numberZero = true;
    [SerializeField] GameObject Doors;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation=Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Poga")
                {
                    StartGateAnimation.getGateAnimation.PlayGateAnimation();
                }
                else if (hit.collider.gameObject.name == "SSArcade")
                {
                    SceneManager.LoadScene("SSStartMenu");
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else if(hit.collider.gameObject.name == "F1Arcade")
                {
                    SceneManager.LoadScene("F1MainMenu");
                    Cursor.lockState = CursorLockMode.Confined;
                }else if (hit.collider.gameObject.name == "PongArcade")
                {
                    SceneManager.LoadScene("PongStartScene");
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else if (hit.collider.gameObject.name == "NumberEight")
                {
                    numberEight = true;
                    CheckForDoors();
                }
                else if (hit.collider.gameObject.name == "NumberThree")
                {
                    numberThree = true;
                    CheckForDoors();
                }
                else if (hit.collider.gameObject.name == "NumberFour")
                {
                    numberFour = true;
                    CheckForDoors();
                }
                else if (hit.collider.gameObject.name == "NumberZero")
                {
                    numberZero = true;
                    CheckForDoors();
                }
                
            }
        }
        
    }
    private void CheckForDoors()
    {
        if(numberEight && numberFour && numberThree && numberZero)
        {
            //Doors.GetComponent<Animation>().Play();

            Doors.GetComponent<Animator>().SetBool("Done", true);
        }
        
    }
    
}
