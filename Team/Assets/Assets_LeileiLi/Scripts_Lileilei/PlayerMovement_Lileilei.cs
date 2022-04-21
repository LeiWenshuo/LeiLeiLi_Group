using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
 * This class will have all the functions that control the player.
 * @Lileilei
 * VERSION 1
 * */

// Mandatory controller
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement_Lileilei : MonoBehaviour
{
    //Gets the location information of the camera object, [SerializeField] similar to the method argument of the Java constructor  
    [SerializeField] private Transform target;
    // jump speed
    public float jumpSpeed = 15.0f;
    // Gravity
    public float gravity = -9.8f;
    // Final speed
    public float endsVelocity = -10.0f;
    // intitial vertical speed
    public float minFall = -1.5f;
    // Running speed
    public float runSpeed = 10;
    // Walking speed
    public float walkSpeed = 4;
    
    private float verSpeed;

    // move speed
    private float moveSpeed;
    //character object
    private CharacterController character;

    public Image[] sprites;
    public int enemyCount;

    public Button btn1,btn2;
    public int count;
    public GameObject pausePanel;
    public GameObject winPanel;
    public AudioSource audio;
    public AudioSource _walkSound;
    public AudioSource _jumpSound;
    public AudioSource background;
    public int killedNumber = 0;
    public float CountDownTime;
    private float GameTime;
    private float timer = 0;
    public Text GameCountTimeText;
    public GameObject gameOverImage;

    //begin every time
    void Start()
    {
        DynamicGI.UpdateEnvironment();
        //initialize
        character = GetComponent<CharacterController>();
        verSpeed = minFall;
        moveSpeed = walkSpeed;
        killedNumber = 0;
        background.Play();
        Time.timeScale = 0;
        GameTime = CountDownTime;

    }
    // complile on every frame
    void Update()
    {
        Timer();
        Movement();
        FinishGame();
        
    }
    /*
     * * Control the movement
     * */
    public void Movement()
    {
             // if (Input.GetKeyDown(KeyCode.Return))
         if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == 1)
            {
                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(true);
                audio.Play();
            }
            else if (count == 2)
            {
                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(false);
                Time.timeScale = 1;
                audio.Play();
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pausePanel.SetActive(true);
            //  Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        // store location 
        Vector3 movement = Vector3.zero;
        // acquire horizontal information
        float horspeed = Input.GetAxis("Horizontal");
        // acquire vertocal information
        float verspeed = Input.GetAxis("Vertical");
        // if moving
        if (horspeed != 0 || verspeed != 0)
        {
            // horizentol location
            movement.x = horspeed * moveSpeed;
            // front and behind location
            movement.z = verspeed * moveSpeed;
            // lateral speed
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            // Translate the movement information into the camera's global coordinates, making sure that you are moving in the camera's direction of view  
            movement = target.TransformDirection(movement);
            if (!_walkSound.isPlaying)
            {
                //	print ("playam hod");
                _walkSound.Play();
                
                _jumpSound.Stop();

            }
        }
        else {
            _walkSound.Stop();
        }
        // changing speed after key down shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        // whether on ground
        if (character.isGrounded)
        {
            // jump speed
            if (Input.GetButtonDown("Jump"))
            {
                verSpeed = jumpSpeed;
                if (_jumpSound)
                    _walkSound.Stop();
                _jumpSound.Play();

            }
            else
            {
                verSpeed = minFall;
                
            }
        }
        else
        {
            // If you are already jumping, decrease the vertical speed to achieve the effect of one down and one up 
            // Time.deltaTime Is expressed as the reciprocal of the refresh rate per second, which is used to control the same speed for each computer  
            verSpeed += gravity * 3 * Time.deltaTime;
            // limit the fastest speed
            if (verSpeed < endsVelocity)
            {
                verSpeed = endsVelocity;
            }
        }
        // Give the movement a vertical velocity
        movement.y = verSpeed;
        //control novement
        movement *= Time.deltaTime;
        character.Move(movement);

    }

    /*
     * The method controls the collision.
     */

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Enemy")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.transform.DOScale(new Vector3(0,0,0),2f);
            sprites[enemyCount].gameObject.SetActive(true);
            enemyCount++;
            killedNumber = killedNumber + 1;
            
        }
    }
    /*
     * Winning condition
     */
     public void FinishGame()
     {
              if (killedNumber == 4)
             {
                  
                 _jumpSound.Stop();
                 _walkSound.Stop();
                 winPanel.SetActive(true);
                 Time.timeScale = 0;

        }
     }
    /*
    * Game over condition. If user cannot finish tasks on time.
    */
    public void Timer()
    {
        int M = (int)(GameTime / 60);
        float S = GameTime % 60;
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            GameTime--;
            GameCountTimeText.text = M + "：" + string.Format("{0:00}", S);
            if (M <= 0 & S <= 0)
            {
                //结束游戏操作
                gameOverImage.SetActive(true);
                _jumpSound.Stop();
                _walkSound.Stop();
                audio.Play();
                GameCountTimeText.gameObject.SetActive(false);
                
                Time.timeScale = 0;
            }
        }
    }
    /*
     *  Set the dialog
     */
    public void getDialog()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        //    Cursor.lockState = CursorLockMode.Locked;

    }
    public void MusicOn()
    {
     
       background.Stop();
    }

    public void MusicOff()
    {

        background.Play();

    }
    /* public void loadScene(string name)
     {
         SceneManager.LoadScene(0);
         DynamicGI.UpdateEnvironment();
     }*/
}
