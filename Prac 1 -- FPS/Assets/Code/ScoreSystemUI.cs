using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemUI : MonoBehaviour
{
    public RectTransform l_ScoreSystemPos;
    public TextMeshPro m_ScoreTxt;
    
    public void Show(Vector3 WorldPosition, float ScorePoints)
    {
        Vector3 l_ScoreSystemViewportPos = GameManager.GetGameManager().GetPlayer().m_Camera.WorldToViewportPoint(WorldPosition);

        if (l_ScoreSystemViewportPos.z > 0.0f)
        {
            Vector2 l_PositionUI = new Vector2(l_ScoreSystemViewportPos.x * 1920.0f, -(1.0f - l_ScoreSystemViewportPos.y) * 1080.0f);
            l_ScoreSystemPos.anchoredPosition = l_PositionUI;
            m_ScoreTxt.text = "+" + ScorePoints.ToString();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
   
}
