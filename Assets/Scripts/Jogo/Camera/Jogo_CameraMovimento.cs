using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Jogo_CameraMovimento : MonoBehaviour
{
    private Vector2 input;
    [SerializeField] private GameObject Camera;
    [SerializeField] private float velocidade;

    private float velocidade_zoom = 1f;
    float zoomatual = 1f;
    float zoom;
    float dif;

    public void Input01(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zoom = zoomatual;

        velocidade_zoom = 1 + zoom * 0.1f;

        Camera.transform.position += new Vector3(input.x * velocidade/100, 0, input.y * velocidade/100) * velocidade_zoom;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // zoom maior
        {
            if (zoom < 15)
            {
                zoom += 2;
            }
            else if (zoom < 18)
            {
                zoom += 3;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // zoom menor
        {
            if (zoom > 18)
            {
                zoom -= 3;
            }
            else if(zoom > 1)
            {
                zoom -= 2;
            }
        }


        //2 == -8.6
        //3 == -9.33
        //4 = -10.05    
        //proporção 1:0,73

        dif = zoom - zoomatual;
        zoomatual += dif;

        //Debug.Log(zoomatual);

        Camera.transform.position += new Vector3(0, dif, (0.73f * dif) * -1);

    }
}
