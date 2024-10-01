//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RotateObject : MonoBehaviour
//{
//    public float rotationSpeed = 1000f;
//    public float decelerationSpeed = 2f; // Dönüþün yavaþlama hýzý
//    private float currentRotationSpeedX; // Þu anki X eksenindeki dönüþ hýzý
//    private bool isDragging = false; // Fare ile dönme iþlemi yapýlýyor mu?

//    void Update()
//    {
//        // Fare sol tuþuna basýldýðýnda objeyi döndür
//        if (Input.GetMouseButton(0))
//        {
//            isDragging = true;

//            // Fare hareketlerini oku
//            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

//            // Fare hareketine göre X ekseninde dönüþ hýzýný ayarla
//            currentRotationSpeedX = -mouseX;

//            // Objeyi sadece X ekseninde döndür
//            transform.Rotate(Vector3.forward, -mouseX, Space.World);
//        }
//        else
//        {
//            // Sol tuþ býrakýldý, artýk yavaþça dönme iþlemi yavaþlayacak
//            if (isDragging)
//            {
//                isDragging = false;
//            }

//            // Dönüþ hýzýný Lerp ile yavaþlat (sadece X ekseninde)
//            currentRotationSpeedX = Mathf.Lerp(currentRotationSpeedX, 0f, decelerationSpeed * Time.deltaTime);

//            // Objenin X ekseninde dönmeye devam etmesi
//            transform.Rotate(Vector3.up, currentRotationSpeedX);
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 1000f;
    public float decelerationSpeed = 2f; // Dönüþün yavaþlama hýzý
    public float currentRotationSpeedZ; // Þu anki Z eksenindeki dönüþ hýzý
    private bool isDragging = false; // Fare ile dönme iþlemi yapýlýyor mu?

    public float targetRotationAngle = 90f; // Çarkýn duracaðý hedef açý
    private bool shouldStopAtTarget = false; // Hedef açýya ulaþýldýðýnda durulup durulmayacaðý

    void Update()
    {
        Debug.Log(currentRotationSpeedZ);
        // Fare sol tuþuna basýldýðýnda objeyi döndür
        if (Input.GetMouseButton(0))
        {
            isDragging = true;

            // Fare hareketlerini oku
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Fare hareketine göre Z ekseninde dönüþ hýzýný ayarla
            currentRotationSpeedZ = -mouseX;

            // Objeyi sadece Z ekseninde döndür
            transform.Rotate(Vector3.forward, -mouseX, Space.World);
        }
        else
        {
            // Sol tuþ býrakýldý, artýk yavaþça dönme iþlemi yavaþlayacak
            if (isDragging)
            {
                isDragging = false;
            }

            // Eðer hedef açýya yaklaþmak istiyorsak
            if (shouldStopAtTarget)
            {
                float currentAngle = transform.rotation.eulerAngles.z; // Z eksenindeki açýyý al

                // Hedef açýya yaklaþtýðýmýzda hýzý azalt
                if (Mathf.Abs(currentAngle - targetRotationAngle) < 5f)
                {
                    currentRotationSpeedZ = Mathf.Lerp(currentRotationSpeedZ, 60f, decelerationSpeed * Time.deltaTime);

                    // Eðer yeterince yaklaþtýysak, dönüþü tamamen durdur
                    if (Mathf.Abs(currentAngle - targetRotationAngle) < 0.1f)
                    {
                        currentRotationSpeedZ = 0f;
                        shouldStopAtTarget = false; // Artýk durdurmaya çalýþmýyoruz
                    }
                }
            }

            // Dönüþ hýzýný Lerp ile yavaþlat (sadece Z ekseninde)
            currentRotationSpeedZ = Mathf.Lerp(currentRotationSpeedZ, 0f, decelerationSpeed * Time.deltaTime);

            // Objenin Z ekseninde dönmeye devam etmesi
            transform.Rotate(Vector3.forward, currentRotationSpeedZ, Space.World);
        }

        // Durdurmak için boþluk tuþuna basýn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStopAtTarget = true; // Hedef açýda durma iþlemini baþlat
        }
    }
}
