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
        public float m_MinDistanceToAttack = 5.0f;
        void SetNextChasePosition()
        {
         Vector3 l_PlayerPosition = GameManager.GetGameManager().GetPlayer().transform.position;
         Vector3 l_Direction = l_PlayerPosition - transform.position;
         l_Direction.Normalize();
         Vector3 l_Position = l_PlayerPosition-l_Direction*m_MinDistanceToAttack;
         m_NavMeshAgent.destination = l_Position;
        }

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


    }
}
