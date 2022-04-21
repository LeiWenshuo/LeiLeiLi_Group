using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    Transform m_transform;

    Player m_player;

    private Transform player;

    UnityEngine.AI.NavMeshAgent m_agent;

    public float m_movSpeed = 3.5f;

    Animator m_ani;

    public float m_rotSpeed = 5.0f;

    float m_timer = 0;

    public  int m_life = 60;
    public int hit_Attact = 25;

    public Slider HP_Enemy;   
    public GameObject Slider_HP_Enemy;

    public GameObject BombPre;

    public GameObject BulletPre;

    public int dis_gj = 15;

    public GameObject YSPre;

    void Start()
    {
        m_transform = this.transform;

        m_ani = this.GetComponent<Animator>();

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.speed = m_movSpeed;
        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_player.life <= 0)
            return;

        m_timer -= Time.deltaTime;

        AnimatorStateInfo stateInfo = m_ani.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.idle02") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idle", false);

            if (m_timer > 0)
                return;

            if (Vector3.Distance(m_transform.position, m_player.transform.position) < dis_gj)
            {
                if (Vector3.Distance(m_transform.position, m_player.transform.position) < 3f)
                {
                    m_agent.ResetPath();
                    m_ani.SetBool("attack", true);
                }
                else
                {
                    m_timer = 1;
                    m_ani.SetBool("run", true);
                    m_agent.SetDestination(GameObject.Find("Player").transform.position);
                }
            }
        }

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("run", false);

            if (m_timer < 0)
            {
                m_agent.SetDestination(GameObject.Find("Player").transform.position);
                m_timer = 1;
            }
        }

        if (Vector3.Distance(m_transform.position, m_player.transform.position) < 3f)
        {
            m_agent.ResetPath();
            m_ani.SetBool("attack", true);
        }

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack01") && !m_ani.IsInTransition(0))
        {
            RotateTo();
            m_ani.SetBool("attack", false);

            if (stateInfo.normalizedTime >= 1.0f)
            {
                m_ani.SetBool("idle", true);
                m_timer = 1;
                m_player.OnDamage(hit_Attact);
            }
        }
    }

    void RotateTo()
    {

        Vector3 targetdir = m_player.transform.position - m_transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, m_rotSpeed * Time.deltaTime, 0.0f);

        m_transform.rotation = Quaternion.LookRotation(newDir);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {

            Destroy(other.gameObject);    
 
            Instantiate(BulletPre, transform.position, Quaternion.identity);
   
            OnDamage(30);
        }
    }

    public void OnDamage(int damage)
    {
        m_life -= damage;
        HP_Enemy.value = m_life;

        if (m_life == 0)
        {
            m_player.Addexperience();

            m_ani.SetBool("death", true);
            Slider_HP_Enemy.SetActive(false);

            m_agent.ResetPath();

            Instantiate(BombPre, transform.position, Quaternion.identity);

            Instantiate(YSPre, transform.position + new Vector3(0,1,0), Quaternion.identity);

            Destroy(this.gameObject, 0.5f);


        }
    }
}
