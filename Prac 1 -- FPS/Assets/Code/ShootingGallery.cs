using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingGallery : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float time;
    private float initialTime;

    [Header("Points")]
    private int m_Count;
    private int m_Goal;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI m_ScoreText;
    [SerializeField] private TextMeshProUGUI m_TimeText;

    [Header("Gallery")]
    private bool m_GalleryOn;
    private Rewards m_Rewards;
    [SerializeField] private GameObject[] m_TargetObjects;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Count = 0;
        initialTime = time;
        m_Goal = 100;

        m_ScoreText.text = "Score:" + m_Count;
        m_TimeText.text = string.Format("{0:00}", time) + "s"; ;

        m_GalleryOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GalleryOn == true)
        {
           time -= Time.deltaTime;
            time = Mathf.Clamp(time, 0,Mathf.Infinity);

            m_TimeText.text = "Time: " + string.Format("{0:00}",time) + "s";

            if(m_Count >= m_Goal)
            {
                Jackpot();
                time = initialTime;

            }
            if (time <= 0)
            {
                GameOver();
                time = initialTime;
            }
           
        }

    }

    public void GainPoits(int count)
    {
        
            Jackpot();
           m_Count += count;
            m_ScoreText.text = "Score" + m_Count;
        
    }

    public void GameOver()
    {
        m_GalleryOn = false;
        m_Count = 0;
        m_ScoreText.text = "Score:" + m_Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_GalleryOn = true;
        }
        else
        {
            m_GalleryOn = false;
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
