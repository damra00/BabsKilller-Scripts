using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class BossCS : MonoBehaviour
{

    [SerializeField] private float Radius = 20;
    [SerializeField] private bool Debug_Bool;
    NavMeshAgent My_Agent;
    Vector3 Next_Position;
    public GameObject Kupa, ParticleObject;
    public float Healt;
    public float Damage;
    float Timer;
    bool CanDamage = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        //AI
        My_Agent = GetComponent<NavMeshAgent>();
        Next_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //AI
        if ((Vector3.Distance(Next_Position, transform.position) <= 1.5f))
        {
            Next_Position = Generic.R_Point_Ge(transform.position, Radius);
            My_Agent.SetDestination(Next_Position);
        }

    }
    void OnDrawGizmos()
    {
        //AI
        if (Debug_Bool == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, Next_Position);
        }

    }
    void OnCollisionStay(Collision collision)
    {
        //Particule �ret
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(ParticleObject, transform.position, transform.rotation);
        }
        //Hasar Ye
        if ((collision.gameObject.tag == "Player") && Healt > 0 && CanDamage)
        {


            Healt -= Damage;

            
            CanDamage = false;
        }
        if (CanDamage == false)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                CanDamage = true;
                Timer = 1f;
            }
        }
        if (Healt <= 0)
        {
            //kupa d�s�r
             Instantiate(Kupa, transform.position, transform.rotation);
             Destroy(gameObject);
        }
    }

}
