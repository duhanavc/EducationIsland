//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Rottt : MonoBehaviour
//{
//    public float RotationSpeed = 1000f;
//    public float TargetRotationAngle;

//    private bool _shouldStop;
//    private float _targetTotalAngle;
//    private float _totalRotatedAngle;


//    float[] angles = new float[] { 337.5f, 247.5f, 112.5f, 22.5f, 67.5f, 157.5f, 292.5f, 202.5f };
//    private DragState _dragState = DragState.None;

//    private enum DragState
//    {
//        None,
//        Dragging,
//        DragEnd,
//    }




//    void Update()
//    {
//        if (Input.GetMouseButton(0) && _dragState != DragState.DragEnd)
//        {
//            var mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
//            transform.Rotate(-Vector3.forward, mouseX, Space.World);
//            _dragState = DragState.Dragging;
//        }
//        else if (Input.GetMouseButton(0) is false && _dragState == DragState.Dragging)
//        {
//            _dragState = DragState.DragEnd;
//            _targetTotalAngle = transform.eulerAngles.z + TargetRotationAngle + 360 * Random.Range(1, 5);
//            _totalRotatedAngle = 0;
//        }
//        else if (_dragState == DragState.DragEnd)
//        {
//            if (_targetTotalAngle - _totalRotatedAngle < 0.1f)
//                _shouldStop = true;

//            if (_shouldStop)
//            {
//                _shouldStop = false;
//                _dragState = DragState.None;
//                transform.eulerAngles = new Vector3(0, 0, -TargetRotationAngle);
//            }
//            else
//            {
//                var rotationAngle = Mathf.Lerp(1500, 100, _totalRotatedAngle / _targetTotalAngle) * Time.deltaTime;
//                _totalRotatedAngle += rotationAngle;
//                transform.Rotate(-Vector3.forward, rotationAngle, Space.World);
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rottt : MonoBehaviour
{
    public float RotationSpeed = 1000f;
    public float TargetRotationAngle;

    private bool _shouldStop;
    private float _targetTotalAngle;
    private float _totalRotatedAngle;

    public List<float> Rotations;
    private List<float> initialRotations; // Ýlk baþtaki deðerleri tutmak için
    private DragState _dragState = DragState.None;

    private enum DragState
    {
        None,
        Dragging,
        DragEnd,
    }

    private void Start()
    {
        // Rotations listesini tanýmlýyoruz
        Rotations = new List<float>() { 337.5f, 247.5f, 112.5f, 22.5f, 67.5f, 157.5f, 292.5f, 202.5f, -22.5f };

        // initialRotations, Rotations'ýn tam tersi sýralamasý olacak
        initialRotations = new List<float>(Rotations); // Rotations listesini kopyala
        initialRotations.Reverse(); // Ters çevir

        Rotations = new List<float>(initialRotations); // Rotations'ý ters sýrayla baþlat
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _dragState != DragState.DragEnd)
        {
            var mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
            transform.Rotate(-Vector3.forward, mouseX, Space.World);
            _dragState = DragState.Dragging;
        }
        else if (!Input.GetMouseButton(0) && _dragState == DragState.Dragging)
        {
            _dragState = DragState.DragEnd;
            ChooseNextTarget();
        }
        else if (_dragState == DragState.DragEnd)
        {
            if (Rotations.Count > 0)
            {
                RotateTowardsTarget();
            }
        }
    }

    private void ChooseNextTarget()
    {
        // Eðer liste boþaldýysa, listeyi tekrar baþtan doldur
        if (Rotations.Count == 0)
        {
            Rotations = new List<float>(initialRotations); // Listeyi ters sýralama ile sýfýrla
            Debug.Log("Rotations list reset");
        }

        if (Rotations.Count > 0)
        {
            int randomIndex = Random.Range(0, Rotations.Count); // Rastgele bir açý seç
            float selectedRotation = Rotations[randomIndex]; // Seçilen açýyý al

            Debug.Log("Selected rotation: " + selectedRotation);

            _targetTotalAngle = GetCurrentZRotation() + selectedRotation + 360 * Random.Range(1, 5); // Hedef açýyý belirle
            _totalRotatedAngle = 0;

            // Seçilen açýyý listeden çýkar
            Rotations.RemoveAt(randomIndex);
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetTotalAngle - _totalRotatedAngle < 0.1f) // Hedef açýya yaklaþýldýðýnda durdur
        {
            _shouldStop = true;
        }

        if (_shouldStop)
        {
            _shouldStop = false;
            _dragState = DragState.None; // Durumu sýfýrla
            Debug.Log("Rotation complete at: " + transform.eulerAngles.z);
        }
        else
        {
            // Dönüþ hýzýný yavaþ yavaþ azalt
            float rotationStep = Mathf.Lerp(1500, 100, _totalRotatedAngle / _targetTotalAngle) * Time.deltaTime;
            _totalRotatedAngle += rotationStep;
            transform.Rotate(-Vector3.forward, rotationStep, Space.World);
        }
    }

    private float GetCurrentZRotation()
    {
        float zRotation = transform.eulerAngles.z;
        if (zRotation > 180) zRotation -= 360; // -180 ile 180 derece arasý dönüþ
        return zRotation;
    }
}
