using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    private int currentToggle;
    private bool xAngle, yAngle, zAngle;
    private float speed = 10f;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = _renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(xAngle ? speed * Time.deltaTime : 0, 
            yAngle ? speed * Time.deltaTime : 0, 
            zAngle ? speed * Time.deltaTime : 0);
    }

    public void ChangeColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetToggle(int number)
    {
        currentToggle = number;
    }
    
    public void ChangeAngle(bool value)
    {
        switch (currentToggle)
        {
            case 0:
                xAngle = value;
                break;
            case 1:
                yAngle = value;
                break;
            case 2:
                zAngle = value;
                break;
        }
    }

    public void ChangeSpeed(float value)
    {
        speed = value;
    }

    public void ChangeOpacity(float value)
    {
        var color = _renderer.material.color;
        color.a = value;
        _renderer.material.SetColor("_Color", color);
    }

    public void ChangeScale(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
}
