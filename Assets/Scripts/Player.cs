using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Ease easeType;
    [SerializeField] private float delay;
    [SerializeField] private float currentSpeed;

    [SerializeField] private float [] xPositionLanes;
    [SerializeField] private float [] speedRange;
    
    [SerializeField] private bool isAlive;
    [SerializeField] private int currentLaneIndex = 1;
    [SerializeField] private int currentSpeedIndex = 1;

    public void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        if(!isAlive)
            return;

        // Side Movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentLaneIndex != 0)
            {
                currentLaneIndex--;
                Vector3 newPosition = new Vector3(xPositionLanes[currentLaneIndex], transform.position.y, transform.position.z);
                transform.DOLocalMove(newPosition, delay).SetEase(easeType);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(currentLaneIndex != 2)
            {
                currentLaneIndex++;
                Vector3 newPosition = new Vector3(xPositionLanes[currentLaneIndex], transform.position.y, transform.position.z);
                transform.DOLocalMove(newPosition, delay).SetEase(easeType);
            }
        }

        // Forward Movement
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    public void Die()
    {
        isAlive = false;
    }
}
