using UnityEngine;

public class Menu_FundoMexer : MonoBehaviour
{
    [SerializeField] private GameObject Objeto;
    private Vector3 MousePos;
    Vector2 imagemPosInicial;
    [SerializeField] private float multBalanço;

    void Start()
    {
        imagemPosInicial = Objeto.transform.position;
    }

    void FixedUpdate()
    {
        //X = 0 a 1920, Y = 0 a 1080
        MousePos = Input.mousePosition;
        Vector2 ScalePos = new Vector2((MousePos.x - 960) / -multBalanço, (MousePos.y - 540) / -multBalanço); //se tem alguma duvida fala comigo (jeony)
        Objeto.transform.position = new Vector3(imagemPosInicial.x + ScalePos.x, imagemPosInicial.y + ScalePos.y);
        Debug.Log(MousePos);
        
    }
}
