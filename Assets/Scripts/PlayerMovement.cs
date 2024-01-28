using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalMouseSensitivity;
    [SerializeField] private float verticalMouseSensitivity;
    [SerializeField] private float maxHeadUpAngle;
    [SerializeField] private float minHeadDownAngle;

    [SerializeField] private float speed;
    [SerializeField] private float speedShiftScale;

    private bool moving;
    private bool hasSpeed;

    private CharacterController characterController;
    private Transform           head;

    //private 

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        head = Camera.main.transform;

        moving = true;
        hasSpeed = true;

    }

    private void OnEnable()
    {
        HideCursor();
    }

    private void OnDisable()
    {
        ShowCursor();
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {

        if (!GameManager.instance.DeathUI.activeSelf)
        { 
            UpdatePlayerRotation();
            UpdateHeadRotation();
            Move();
        }


        moving = !GameManager.instance.MapUILogic.Animator.GetBool("Open");

            if (moving)
        {
            
        }
        else
            hasSpeed = false;
        
    }

    private void UpdatePlayerRotation()
    {
        float rotation = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHeadRotation()
    {
        Vector3 rotation = head.localEulerAngles;

        rotation.x -= Input.GetAxis("Mouse Y") * verticalMouseSensitivity;

        if (rotation.x < 180)
            rotation.x = Mathf.Min(rotation.x, maxHeadUpAngle);
        else
            rotation.x = Mathf.Max(rotation.x, minHeadDownAngle);

        head.localEulerAngles = rotation;
    }

    private void Move()
    {

        

        float x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float z = Input.GetAxis("Horizontal")  * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            x *= speedShiftScale;
            z *= speedShiftScale;
            GameManager.instance.RunningUI.SetActive(true);
        }
        else
        {
            GameManager.instance.RunningUI.SetActive(false);
        }

        if(!moving)
        {
            x = 0;
            z = 0;
            GameManager.instance.RunningUI.SetActive(false);
        }

        if (x != 0 || z != 0)
        {
            hasSpeed = true;
        }
        else
            hasSpeed = false;

        Vector3 move = transform.right * z + transform.forward * x;

        characterController.Move(move);
    }

    public void SetSensitivity(float sensitivity)
    {
        horizontalMouseSensitivity = sensitivity;
        verticalMouseSensitivity   = sensitivity;
    }

    public void EnableMovement() => moving = true;

    public void DisableMovement() => moving = false;

    public float GetSensitivity()
    {
        return horizontalMouseSensitivity;
    }

    public float GetVerticalSensitivity()
    {
        return verticalMouseSensitivity;
    }

    public bool GetHasSpeed() => hasSpeed;

}
