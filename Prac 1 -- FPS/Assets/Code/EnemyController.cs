using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent m_NavMeshAgent;
    public Transform m_Target;
    TState m_State;

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
        void SetIdleState()
        {
            m_State = TState.IDLE;
        }
        void UpdateIdleState()
        {
        }
        void SetPatrolState()
        {
            m_State = TState.PATROL;
        }
        void UpdatePatrolState()
        {
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

        void SetNextChasePosition()
        {
            Vector3 l_Position;
            m_NavMeshAgent.destination = l_Position;
        }
    }

    
}
