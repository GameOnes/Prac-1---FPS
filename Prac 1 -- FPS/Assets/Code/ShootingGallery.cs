using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingGallery : MonoBehaviour
{
    [Header("Time")]
    private float m_TimeLimit = 60;
    private float m_TimeRemaining;

    [Header("Points")]
    private int m_Count;
    private int m_Goal;

    [Header("Text")]
    [SerializeField] private TextMeshPro m_ScoreText;
    [SerializeField] private TextMeshPro m_TimeText;

    [Header("Gallery")]
    private bool m_GalleryOn;
    private Rewards m_Rewards;
    [SerializeField] private GameObject[] m_TargetObjects;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Count = 0;
        m_TimeRemaining = m_TimeLimit;
        m_Goal = 100;

        m_ScoreText.text = "Score:" + m_Count;
        m_TimeText.text = "Time: " + m_TimeRemaining + "s";

        m_GalleryOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GalleryOn == true)
        {
            m_TimeRemaining -= Time.deltaTime;
            m_TimeRemaining = Mathf.Clamp(m_TimeRemaining, 0, m_TimeLimit);

            m_TimeText.text = "Time: " + m_TimeRemaining + "s";

            if (m_TimeRemaining <= 0)
            {
                GameOver();
                m_TimeRemaining = m_TimeLimit;
            }
            if (m_Count >= m_Goal)
            {
                GameOver();
                m_TimeRemaining = m_TimeLimit;
            }
        }

    }

    public void GainPoits(int count)
    {
        if (m_GalleryOn == true)
        {
            m_Count += count;
            m_ScoreText.text = "Score" + count;
        }
    }

    public void GameOver()
    {
        m_GalleryOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_GalleryOn = true;
        }
    }

    private enum Rewards
    {
        BasicTarget,
        Advancetarget,
        MovingTarget
    }

    private void Jackpot()
    {
        if(m_GalleryOn == true)
        {
            switch (m_Rewards)
            {
                case Rewards.BasicTarget:
                    m_Count = m_Count + 1;
                    break;
                case Rewards.Advancetarget:
                    m_Count = m_Count + 5;
                    break;
                case Rewards.MovingTarget:
                    m_Count= m_Count + 10;
                    break;
            }
        }
    }
}
