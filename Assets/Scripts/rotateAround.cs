using UnityEngine;

public class rotateAround : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
    }
}
