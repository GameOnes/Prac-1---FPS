using UnityEngine;
public class PlayerController : MonoBehaviour
{
    float m_Yaw;
    float m_Pitch;
    public float m_YawSpeed;
    public float m_PitchSpeed;
    public float m_MinPitch;
    public float m_MaxPitch;
    public Transform m_PitchController;
    public bool m_UseInvertedYaw;
    public bool m_UseInvertedPitch;
    public CharacterController m_CharacterController;
    float m_VerticalSpeed=0.0f;

    bool m_AngleLocked=false;
    public float m_Speed;
    public float m_JumpSpeed;
    public float m_SpeedMultiplier;

    [Header("Camera")]
    public Camera m_Camera;
    public float m_ShootMaxDistance=50.0f;

    [Header("Shoot")]
    public LayerMask m_ShootLayerMask;
    public GameObject m_ShootParticles;
 
    [Header("Input")]
    public KeyCode m_LeftKeyCode=KeyCode.A;
    public KeyCode m_RightKeyCode=KeyCode.D;
    public KeyCode m_UpKeyCode=KeyCode.W;
    public KeyCode m_DownKeyCode=KeyCode.S;
    public KeyCode m_JumpKeyCode=KeyCode.Space;
    public KeyCode m_RunKeyCode=KeyCode.LeftShift;
    public KeyCode m_ReloadKeyCode = KeyCode.R;
    public int m_ShootMouseButton = 0;

    public int m_PlayerLife=3;

    [Header("Debug Input")]
    public KeyCode m_DebugLockAngleKeyCode=KeyCode.I;

    [Header("Animation")]
    public Animation m_Animation;
    public AnimationClip m_IdleAnimationClip;
    public AnimationClip m_ShootAnimationClip;
    public AnimationClip m_ReloadAnimationClip;


    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        SetIdleAnimation();
    }
    void Update()
    {
        float l_MouseX=Input.GetAxis("Mouse X");
        float l_MouseY=Input.GetAxis("Mouse Y");

        if(Input.GetKeyDown(m_DebugLockAngleKeyCode))
            m_AngleLocked=!m_AngleLocked;

        if(!m_AngleLocked)
        {
            m_Yaw=m_Yaw+l_MouseX*m_YawSpeed*Time.deltaTime*(m_UseInvertedYaw ? -1.0f : 1.0f);
            m_Pitch=m_Pitch+l_MouseY*m_PitchSpeed*Time.deltaTime*(m_UseInvertedPitch ? -1.0f : 1.0f);
            m_Pitch=Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);
            transform.rotation=Quaternion.Euler(0.0f, m_Yaw, 0.0f);
            m_PitchController.localRotation=Quaternion.Euler(m_Pitch, 0.0f, 0.0f);
        }
        
        Vector3 l_Movement=Vector3.zero;
        float l_YawPiRadians=m_Yaw*Mathf.Deg2Rad;
        float l_Yaw90PiRadians=(m_Yaw+90.0f)*Mathf.Deg2Rad;
        Vector3 l_ForwardDirection=new Vector3(Mathf.Sin(l_YawPiRadians), 0.0f, Mathf.Cos(l_YawPiRadians));
        Vector3 l_RightDirection=new Vector3(Mathf.Sin(l_Yaw90PiRadians), 0.0f, Mathf.Cos(l_Yaw90PiRadians));

        if(Input.GetKey(m_RightKeyCode))
            l_Movement=l_RightDirection;
		else if(Input.GetKey(m_LeftKeyCode))
            l_Movement=-l_RightDirection;

        if(Input.GetKey(m_UpKeyCode))
            l_Movement+=l_ForwardDirection;
		else if(Input.GetKey(m_DownKeyCode))
            l_Movement-=l_ForwardDirection;

        float l_SpeedMultiplier=1.0f;

        if(Input.GetKey(m_RunKeyCode))
            l_SpeedMultiplier=m_SpeedMultiplier;

        l_Movement.Normalize();
        l_Movement*=m_Speed*l_SpeedMultiplier*Time.deltaTime;
        
        m_VerticalSpeed=m_VerticalSpeed+Physics.gravity.y*Time.deltaTime;
        l_Movement.y=m_VerticalSpeed*Time.deltaTime;
        
		CollisionFlags l_CollisionFlags=m_CharacterController.Move(l_Movement);
        if(m_VerticalSpeed<0.0f && (l_CollisionFlags & CollisionFlags.Below)!=0) //si estoy cayendo y colisiono con el suelo
        {
            m_VerticalSpeed=0.0f;
            if(Input.GetKeyDown(m_JumpKeyCode))
                m_VerticalSpeed=m_JumpSpeed;
        }
        else if(m_VerticalSpeed>0.0f && (l_CollisionFlags & CollisionFlags.Above)!=0) //si estoy subiendo y colision con un techo
            m_VerticalSpeed=0.0f;
        if (CanShoot() && Input.GetMouseButtonDown(m_ShootMouseButton))
            Shoot();
        if (CanReload() && Input.GetKeyDown(m_ReloadKeyCode))
            Reload();
    }
    bool CanReload()
    {
        return true;
    }
    void Reload()
    {
        SetReloadAnimation();
    }
    bool CanShoot()
    {
        return true;
    }

    void Shoot()
    {
        SetShootAnimation();
        Ray l_Ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if (Physics.Raycast(l_Ray, out RaycastHit l_RayCastHit, m_ShootMaxDistance, m_ShootLayerMask.value))
            CreateShootHitParticles(l_RayCastHit.point, l_RayCastHit.normal);
    }
    void CreateShootHitParticles(Vector3 Position, Vector3 Normal)
    {
        GameObject l_ShootParticles = GameObject.Instantiate(m_ShootParticles);
        l_ShootParticles.transform.position = Position;
        l_ShootParticles.SetActive(true);
    }
   

    // animation es más comodo para un perosnaje 3d porque puedes hacerlo directamente aaqui
    //mientras que con animator tienes que crear un controlador de animacion y es mas pesado, mas util para crear animaciones de por ejemplo un menu
    void SetIdleAnimation()
    {
        m_Animation.CrossFade(m_IdleAnimationClip.name,0.0f);
        
    }
    void SetReloadAnimation()
    {
        m_Animation.CrossFade(m_ReloadAnimationClip.name, 0.1f);
        m_Animation.CrossFadeQueued(m_IdleAnimationClip.name, 0.0f);
    }

    void SetShootAnimation()
    {
        m_Animation.CrossFade(m_ShootAnimationClip.name, 0.1f);
        m_Animation.CrossFadeQueued(m_IdleAnimationClip.name, 0.0f);

    }


}



