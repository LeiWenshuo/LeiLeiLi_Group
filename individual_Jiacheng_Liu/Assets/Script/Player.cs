using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public GameManager gameManager;

    public float speed;
    public float rotspeed;
    public GameObject bolt;
    public Transform gun;

    public float firerate;
    private float nextfire;
    private float nextfire_ani = 0;
    private bool nextfire_of = false;

    public Animator animBoy;
  
    public int life = 100;
    public Slider HP_zj;
    public AudioSource Get_Sound;
    public AudioSource HP_Sound;
    public GameObject FxPre;    
    public AudioSource hurtSound;

    public int SP_life = 100;
    public Slider SP_zj;

    public Text Text_PlayTime;
    public bool Run_Time = true;
    public float Time_Run = 60;

    public CharacterController PlayerMove;
    public float gravity = 10f;

    public MessageBoardController messageBoardController;

    public GameObject FT;
    public GameObject FT_UI;
    public Button FT_UIButton;
    public bool FT_bool = false;
    public AudioSource FTSound;

    public GameObject silver;
    public GameObject silver_UI;
    public Button silver_UIButton;
    public bool silver_bool = false;
    public AudioSource silverSound;

    public int YS_int = 0;
    public GameObject NPC_UI;
    public Button NPC_UIButton;
    public bool NPC_bool = false;

    public int tree_num = 0;
    public Text tree_Text;
    public bool tree_bool = false;
    private GameObject tree;

    public int flower_num = 0;
    public Text flower_Text;
    public bool flower_bool = false;
    private GameObject flower;

    public GameObject Character01;

    public GameObject Character01UI;
 

    void Start()
    {
        FT_UIButton.onClick.AddListener(FT_UIButtonListener);
        silver_UIButton.onClick.AddListener(silver_UIButtonListener);

        NPC_UIButton.onClick.AddListener(NPC_UIButtonListener);

        Character01.SetActive(true);

        Character01UI.SetActive(true);
    }

    void Update()
    {
        if (life <= 0)
        {
            return;
        }

        if (Input.GetKey(KeyCode.J) && Time.time > nextfire && SP_life >= 5)
        {
            SP_life -= 5;
            SP_zj.value = SP_life;

            nextfire = Time.time + firerate;

            Instantiate(bolt, gun.position, gun.rotation);

            animBoy.SetBool("Gongjiing", true);
 
            nextfire_of = true;
        }

        if (Input.GetKey(KeyCode.K) && Time.time > nextfire)
        {
            FTSound.Play();

            nextfire = Time.time + firerate;

            animBoy.SetBool("Attact_Tree", true);

            nextfire_of = true;

            
            if (tree_bool == true && messageBoardController.num_03 == 1)
            {
                Destroy(tree.gameObject);

                tree_num++;
                tree_Text.text = string.Format("{0:0}", tree_num);
            }
        }

        if (Input.GetKey(KeyCode.L) && Time.time > nextfire)
        {
            silverSound.Play();

            nextfire = Time.time + firerate;

            animBoy.SetBool("Attact_flower", true);

            nextfire_of = true;

            if (flower_bool == true && messageBoardController.num_04 == 1)
            {
                Destroy(flower.gameObject);

                flower_num++;
                flower_Text.text = string.Format("{0:0}", flower_num);
            }
        }

        if (nextfire_of == true)
        {
            nextfire_ani += Time.deltaTime;

            if (nextfire_ani > 0.5)
            {
                animBoy.SetBool("Gongjiing", false);
                animBoy.SetBool("Attact_Tree", false);
                animBoy.SetBool("Attact_flower", false);

                nextfire_of = false;
                nextfire_ani = 0;
            }
        }

        float x = 0, y = 0, z = 0;
   
        y -= gravity * Time.deltaTime;
 
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
            x = 1;
            transform.Rotate(Vector3.up * Time.deltaTime * -rotspeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
            transform.Rotate(Vector3.up * Time.deltaTime * rotspeed);
        }
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animBoy.SetTrigger("Jump");

            y += gravity * 30 * Time.deltaTime;
        }
        if (this.gameObject.transform.position.y >= 1.5)
        {
            y -= gravity * 10 * Time.deltaTime;
        }

        PlayerMove.Move(transform.TransformDirection(new Vector3(0, y, z)));

        if (z != 0 || x == 1)
        {
            animBoy.SetBool("Moving", true);
        }
        else
        {
            animBoy.SetBool("Moving", false);
        }
        if (Run_Time == true)
        {
            Time_Run -= Time.deltaTime;
            Text_PlayTime.text = string.Format("{0:0}", Time_Run);

            if (Time_Run <= 0)
            {
                Time_Run = 0;
                Text_PlayTime.text = string.Format("{0:0}", Time_Run);
               
                SceneManager.LoadScene(3);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "HP")
        {
            Get_Sound.Play();
            Destroy(other.gameObject);

            messageBoardController.Add_01();
        }
     
        if (other.tag == "SP")
        {
            Get_Sound.Play();
            Destroy(other.gameObject);

            messageBoardController.Add_02();
        }

   
        if (other.tag == "FT")
        {
            FT_UI.SetActive(true);
            FT_bool = true;
        }
   
        if (other.tag == "silver")
        {
            silver_UI.SetActive(true);
            silver_bool = true;
        }

 
        if (other.tag == "NPC")
        {
            NPC_UI.SetActive(true);
            NPC_bool = true;
        }


        if (other.tag == "YS")
        {
            YS_int++;

            Get_Sound.Play();
            Destroy(other.gameObject);

            messageBoardController.Add_05();
        }


        if (other.tag == "Tree")
        {
            tree = other.gameObject;
            tree_bool = true;
        }

     
        if (other.tag == "flower")
        {
            flower = other.gameObject;
            flower_bool = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "FT")
        {
            FT_UI.SetActive(false);
            FT_bool = false;
        }
        if (other.tag == "silver")
        {
            silver_UI.SetActive(false);
            silver_bool = false;
        }
     
        if (other.tag == "NPC")
        {
            NPC_UI.SetActive(false);
            NPC_bool = false;
        }

        if (other.tag == "Tree")
        {
            tree_bool = false;
        }

        if (other.tag == "flower")
        {
            flower_bool = false;
        }
    }

    public void FT_UIButtonListener()
    {
        FT_UI.SetActive(false);
        Get_Sound.Play();

        Destroy(FT);
        messageBoardController.Add_03();
    }

    public void silver_UIButtonListener()
    {
        silver_UI.SetActive(false);
        Get_Sound.Play();

        Destroy(silver);
        messageBoardController.Add_04();
    }

    public void NPC_UIButtonListener()
    {
        if (YS_int == 3)
         {
             SceneManager.LoadScene(3);
         }
        else
        {
            NPC_UI.SetActive(false);
            NPC_bool = false;
        }
    }

    public void OnDamage(int damage)
    {
        
        Vector3 decalPos = this.gameObject.transform.position + (Vector3.up * 0.3f);
        Quaternion decalRot = Quaternion.Euler(90, 0, Random.Range(0, 360));
        GameObject blood2 = (GameObject)Instantiate(FxPre, decalPos, decalRot);
        float scale = Random.Range(1.5f, 3.5f);
        blood2.transform.localScale = Vector3.one * scale;
        Destroy(blood2, 2.0f);
        hurtSound.Play();

        life -= damage;
       
        HP_zj.value = life;

        if (life <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void AddHp()
    {
        HP_Sound.Play();
  
        if (life > 80)
        {
            life = 100;
        }
        else
        {
            life += 20;
        }
        HP_zj.value = life;
    }

    public void AddSp()
    {
        HP_Sound.Play();

        if (SP_life > 40)
        {
            SP_life = 100;
        }
        else
        {
            SP_life += 40;
        }
        SP_zj.value = SP_life;
    }

    public void Addexperience()
    {
        gameManager.SetScore(1);
    }

}
