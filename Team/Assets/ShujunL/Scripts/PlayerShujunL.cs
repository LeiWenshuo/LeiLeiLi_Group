using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShujunL : MonoBehaviour
{

    private new Transform transform;
    private CharacterController controller;
    public Transform cameraTransform;  
    private Vector3 cameraRotation;    
    public float speed = 10.0f;

    public GameObject winText;
    public Text BStext;
    private int BSscore = 0;

    public AudioSource CoinSound;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.GetComponent<Transform>();       
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    private void Control()
    {
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        cameraRotation.x -= rv;
        cameraRotation.y += rh;
        cameraTransform.eulerAngles = cameraRotation;

        Vector3 camrot = cameraTransform.eulerAngles;
        camrot.x = 0; camrot.z = 0;
        transform.eulerAngles = camrot;

        cameraTransform.position = transform.TransformPoint(0, 2.3f, -2.6f);

        float x = 0, y = -0.6f, z = 0;

        if (Input.GetKey(KeyCode.W))
        {
            z += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            z -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += speed * Time.deltaTime;
        }
      
        controller.Move(transform.TransformDirection(new Vector3(x, y, z)));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "BS")
        {
            CoinSound.Play();

            BSscore++;
            BStext.text = BSscore.ToString();
            if (BSscore == 6)
            {
                winText.SetActive(true);
            }
            Destroy(collider.gameObject);
        }
    }

}



