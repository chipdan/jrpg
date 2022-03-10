using UnityEngine;
using System.Collections;
using UnityEngine.AI;

 
public class Movment : MonoBehaviour
{
    public Transform goal;
    public CharacterController controller_player;
    public NavMeshAgent agent_player;
    public Transform player;
    public float speed = 1f;
    [SerializeField]public int rot = 0;
    private void Start()
    {
        controller_player = GetComponent<CharacterController>();
        agent_player = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        goal = GameObject.FindWithTag("end_move").transform;
        UnityEngine.AI.NavMeshAgent agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        if (rot == 1)
        {
            StartCoroutine(Rotat());
            if (player.transform.eulerAngles.y == 180)
            {
                rot = 0;
            }
        }
    }
    private IEnumerator Rotat()
    {
        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        player.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        yield return new WaitForSeconds(0);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "move")
        {
            controller_player.enabled = false;
            agent_player.enabled = true;
        }
        else if (other.gameObject.tag == "end_move")
        {
            agent_player.enabled = false;
            controller_player.enabled = true;
            rot = 1;
        }
    }

    }

