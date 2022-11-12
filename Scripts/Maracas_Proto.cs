
using UnityEngine;
using Unity.Mathematics;
public class Maracas_Proto : MonoBehaviour
{
    public float smooth = 0.4f;
    public float VRotate;
    public float Sensibility = 4;
    private Vector3 C_Accelerometer, I_Accelerometer;
    // Start is called before the first frame update
    void Start()
    {
        I_Accelerometer = Input.acceleration;
        C_Accelerometer = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        C_Accelerometer = Vector3.Lerp(C_Accelerometer, Input.acceleration - I_Accelerometer, Time.deltaTime / smooth);
        VRotate = Mathf.Clamp(C_Accelerometer.x * Sensibility, -1, 1);
        transform.Rotate(0, 0, -VRotate);
    }
}
