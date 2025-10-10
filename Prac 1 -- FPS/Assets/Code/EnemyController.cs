using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent m_NavMeshAgent;
    public Transform m_Target;
    TState m_State;

    public List<Transform> m_PatrolPositions;
    int m_CurrentPatrolPositionId = 0;

    public float m_SightAngle = 60.0f;
    public LayerMask m_SightLayerMask;
    public float m_EyesHeight = 1.0f;

    public float m_MaxHearDistance;

    private void Awake()
    {
       m_NavMeshAgent = GetComponent<NavMeshAgent>();
  
    }

    enum TState
    {
        IDLE = 0,
        PATROL,
        ALERT,
        ATTACK,
        CHASE,
        HIT,
        DIE
    }

    private void Update()
    {
        switch (m_State)
        {
            case TState.IDLE:
                UpdateIdleState();
                break;
            case TState.PATROL:
                UpdatePatrolState();
                break;
            case TState.ALERT:
                UpdateAlertState();
                break;
            case TState.ATTACK:
                UpdateAttackState();
                break;
            case TState.CHASE:
                UpdateChaseState();
                break;
            case TState.HIT:
                UpdateHitState();
                break;
            case TState.DIE:
                UpdateDieState();
                break;
        }
    }
    void SetIdleState()
    {
        m_State = TState.IDLE;
    }
    void UpdateIdleState()
    {
        SetPatrolState();
    }
    void SetPatrolState()
    {
        m_State = TState.PATROL;
        m_CurrentPatrolPositionId = 0;
        MoveToNextPatrolPosition();
    }
    void UpdatePatrolState()
    {
        if(m_NavMeshAgent.hasPath && m_NavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            MoveToNextPatrolPosition();
        }
        if (HearsPlayer())
        {
            SetAlertState();
        }
    }
    void SetAlertState()
    {
        m_State = TState.ALERT;
    }
    void UpdateAlertState()
    {
    }
    void SetAttackState()
    {
        m_State = TState.ATTACK;
    }
    void UpdateAttackState()
    {
    }
    void SetChaseState()
    {
        m_State = TState.CHASE;
    }
    void UpdateChaseState()
    {
    }
    void SetHitState()
    {
        m_State = TState.PATROL;
    }
    void UpdateHitState()
    {
    }
    void SetDieState()
    {
        m_State = TState.PATROL;
    }
    void UpdateDieState() 
    {
    }

    public float m_MinDistanceToAttack = 5.0f;
    void SetNextChasePosition()
    {
        Vector3 l_PlayerPosition = GameManager.GetGameManager().GetPlayer().transform.position;
        Vector3 l_Direction = l_PlayerPosition - transform.position;
        l_Direction.Normalize();
        Vector3 l_Position = l_PlayerPosition-l_Direction*m_MinDistanceToAttack;
        m_NavMeshAgent.destination = l_Position;
    }
    /*
     Crearemos el método MoveToNextPatrolposition dónde establecerá la posición de destino del Patrol en el NavMeshAgent,
     para ello utilizaremos una lista de puntos Patrulla para cada enemigo.
     */
    void MoveToNextPatrolPosition()
    {
        Vector3 l_Destination = m_PatrolPositions[m_CurrentPatrolPositionId].position;
        m_NavMeshAgent.destination = l_Destination;
        ++m_CurrentPatrolPositionId;
        if (m_CurrentPatrolPositionId > m_PatrolPositions.Count)
        {
            m_CurrentPatrolPositionId = 0;
        }
    }
    /*
     Crearemos el método SeesPlayer que nos devolverá verdadero o falso si vemos al player, para ello deberemos
    utilizar un Raycast entre "los ojos" del player y la posición del enemigo, encaso de colisionar con le enemigo que
    decidir que ve al enemigo, en caso de colisionar con otro objeto que no sea el enemigo
    querrá decir que no ve al player.Podemos utilizar una capa para el player para comprobar que no colosione con nadie
    Deberemos comprobar tambien que el enemigo esta mirando en la direccion del player, para ello utilizaremos el 
    producto escalar entre dos vectores.
     */
    bool SeesPlayer()
    {
        Vector3 l_PlayerPosition = GameManager.GetGameManager().GetPlayer().transform.position;
        Vector3 l_Direction = l_PlayerPosition - transform.position;
        float l_Distance = l_Direction.magnitude;
        //l_Direction.Normalize();
        l_Direction /= l_Distance;
        float l_DotValue = Vector3.Dot(l_Direction, transform.forward);

        if (l_DotValue >= Mathf.Cos(m_SightAngle * 0.0f * Mathf.Deg2Rad))
        {
            Ray l_Ray = new Ray(transform.position+Vector3.up*m_EyesHeight,l_Direction);
            //float l_Distance = Vector3.Distance(l_PlayerPosition, transform.position);
            if (!Physics.Raycast(l_Ray,l_Distance,m_SightLayerMask.value))
            {
                return true;
            }
        }
        return false;
    }
    /*
     Crearemos el metodo HearsPlayer donde nos devolvera true o false si el player esta a una distancia minima de alerta del enemigo
    */

    bool HearsPlayer()
    {

        Vector3 l_PlayerPosition = GameManager.GetGameManager().GetPlayer().transform.position;
        //float l_Distance = l_Direction.magnitude;
        return true;
    }

}
    


