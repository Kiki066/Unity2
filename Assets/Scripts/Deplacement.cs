
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMotor))]

public class Deplacement : MonoBehaviour
{
    AudioSource m_Source;
    


    [SerializeField]        //permet de faire apparaitre speed dans Unity
    private float speed = 2f;

    [SerializeField]
    private float mouseSensitivityX = 3f;

    [SerializeField]
    private float mouseSensitivityY = 3f;

    //SONS--------------------------
    [SerializeField]
    private AudioClip walk;

    



    private PlayerMotor motor;

    static Animator anim;
   

    
    ////////////////////
    private bool isMoving = false;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();
        m_Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        


        //Calcul de la vitesse du joueur
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        //On calcule la rotation duu joueur en un vector3

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);

        //On calcule la rotation de la caméra du joueur en un vector3

        float xRot = Input.GetAxisRaw("Mouse Y");

        float cameraRotationX = xRot * mouseSensitivityY;

        motor.RotateCamera(cameraRotationX);

        


        //COURIR---------------------------------
        if(Input.GetKey("z") && Input.GetKey(KeyCode.LeftShift))
        {
            if(speed < 6f)
                speed = speed + 1f;
            anim.SetBool("isRunning", true);
            m_Source.pitch = 1.5f;
        }
        else
        {
            if(speed > 2f)
                speed = speed - 1f;
            anim.SetBool("isRunning", false);
            m_Source.pitch = 1f;
        }

        if (Input.GetKey("q") && Input.GetKey("z"))
        {
            anim.SetBool("isGoingLeft", true);
        }
        else
        {
            anim.SetBool("isGoingLeft", false);
        }

        if (Input.GetKey("d") && Input.GetKey("z"))
        {
            anim.SetBool("isGoingRight", true);
        }
        else
        {
            anim.SetBool("isGoingRight", false);
        }

        //--------------------------------------
        //RECUL---------------------------
        if (Input.GetKey("s"))
        {
            anim.SetBool("isGoingBack", true);
        }
        else
        {
            anim.SetBool("isGoingBack", false);
        }

        if (Input.GetKey("s") && Input.GetKey("q"))
        {
            anim.SetBool("isGoingBackLeft", true);
        }
        else
        {
            anim.SetBool("isGoingBackLeft", false);
        }

        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            anim.SetBool("isGoingBackRight", true);
        }
        else
        {
            anim.SetBool("isGoingBackRight", false);
        }
        //AVANCE-----------------------------------------

        if (Input.GetKey("z"))
        {
            anim.SetBool("isWalking", true);
           
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey("z") && Input.GetKey("q"))
        {
            anim.SetBool("isWalkingLeft", true);
        }
        else
        {
            anim.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey("z") && Input.GetKey("d"))
        {
            anim.SetBool("isWalkingRight", true);
        }
        else
        {
            anim.SetBool("isWalkingRight", false);
        }



        if (Input.GetKey("q"))
        {
            anim.SetBool("isLeft", true);
        }
        else
        {
            anim.SetBool("isLeft", false);
        }

        if (Input.GetKey("d"))
        {
            anim.SetBool("isRight", true);
        }
        else
        {
            anim.SetBool("isRight", false);
        }

        if(Input.GetKeyDown("z"))
        {
            if(!(MenuPause.jeuEnPause))
            {
                m_Source.clip = walk;
                m_Source.Play();
            }
            
        }
        if(Input.GetKeyUp("z"))
        {
            m_Source.Stop();
        }

        //PAUSE---------------------------------------
       

    }
}
