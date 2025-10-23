using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class LifeBarElementUI : MonoBehaviour
{
    public RectTransform m_LifeBarUIRectTransform;
    public Image m_ForegroundLifeBarUI;

    public RectTransform m_ForegroundRect;
    private float m_OriginalForegroundWidth;

    void Awake()
    {
        if (m_ForegroundRect == null && m_ForegroundLifeBarUI != null)
            m_ForegroundRect = m_ForegroundLifeBarUI.GetComponent<RectTransform>();

        if (m_ForegroundRect != null)
            m_OriginalForegroundWidth = m_ForegroundRect.rect.width;
    }

    public void Show(Vector3 WorldPosition, float LifePct)
    {
        Vector3 l_LifeBarViewportPosition = GameManager.GetGameManager().GetPlayer().m_Camera.WorldToViewportPoint(WorldPosition);

        if (l_LifeBarViewportPosition.z > 0.0f) // comprueba que la barra de vida este delante de la camara
        {
            Vector2 l_PositionUI = new Vector2(l_LifeBarViewportPosition.x * 1920.0f, -(1.0f - l_LifeBarViewportPosition.y) * 1080.0f); // convierte la posicion del mundo a la posicion de la UI
            m_LifeBarUIRectTransform.anchoredPosition = l_PositionUI; // asigna la posicion de la UI

            float clamp = Mathf.Clamp01(LifePct);
            if (m_ForegroundRect != null)
            {
                m_ForegroundRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_OriginalForegroundWidth * clamp);
            }
            else if (m_ForegroundLifeBarUI != null && m_OriginalForegroundWidth > 0f)
            {
                m_ForegroundLifeBarUI.fillAmount =clamp; // asigna el porcentaje de vida

            }
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

   
}
