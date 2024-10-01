//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RotateObject : MonoBehaviour
//{
//    public float rotationSpeed = 1000f;
//    public float decelerationSpeed = 2f; // D�n���n yava�lama h�z�
//    private float currentRotationSpeedX; // �u anki X eksenindeki d�n�� h�z�
//    private bool isDragging = false; // Fare ile d�nme i�lemi yap�l�yor mu?

//    void Update()
//    {
//        // Fare sol tu�una bas�ld���nda objeyi d�nd�r
//        if (Input.GetMouseButton(0))
//        {
//            isDragging = true;

//            // Fare hareketlerini oku
//            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

//            // Fare hareketine g�re X ekseninde d�n�� h�z�n� ayarla
//            currentRotationSpeedX = -mouseX;

//            // Objeyi sadece X ekseninde d�nd�r
//            transform.Rotate(Vector3.forward, -mouseX, Space.World);
//        }
//        else
//        {
//            // Sol tu� b�rak�ld�, art�k yava��a d�nme i�lemi yava�layacak
//            if (isDragging)
//            {
//                isDragging = false;
//            }

//            // D�n�� h�z�n� Lerp ile yava�lat (sadece X ekseninde)
//            currentRotationSpeedX = Mathf.Lerp(currentRotationSpeedX, 0f, decelerationSpeed * Time.deltaTime);

//            // Objenin X ekseninde d�nmeye devam etmesi
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
    public float decelerationSpeed = 2f; // D�n���n yava�lama h�z�
    public float currentRotationSpeedZ; // �u anki Z eksenindeki d�n�� h�z�
    private bool isDragging = false; // Fare ile d�nme i�lemi yap�l�yor mu?

    public float targetRotationAngle = 90f; // �ark�n duraca�� hedef a��
    private bool shouldStopAtTarget = false; // Hedef a��ya ula��ld���nda durulup durulmayaca��

    void Update()
    {
        Debug.Log(currentRotationSpeedZ);
        // Fare sol tu�una bas�ld���nda objeyi d�nd�r
        if (Input.GetMouseButton(0))
        {
            isDragging = true;

            // Fare hareketlerini oku
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Fare hareketine g�re Z ekseninde d�n�� h�z�n� ayarla
            currentRotationSpeedZ = -mouseX;

            // Objeyi sadece Z ekseninde d�nd�r
            transform.Rotate(Vector3.forward, -mouseX, Space.World);
        }
        else
        {
            // Sol tu� b�rak�ld�, art�k yava��a d�nme i�lemi yava�layacak
            if (isDragging)
            {
                isDragging = false;
            }

            // E�er hedef a��ya yakla�mak istiyorsak
            if (shouldStopAtTarget)
            {
                float currentAngle = transform.rotation.eulerAngles.z; // Z eksenindeki a��y� al

                // Hedef a��ya yakla�t���m�zda h�z� azalt
                if (Mathf.Abs(currentAngle - targetRotationAngle) < 5f)
                {
                    currentRotationSpeedZ = Mathf.Lerp(currentRotationSpeedZ, 60f, decelerationSpeed * Time.deltaTime);

                    // E�er yeterince yakla�t�ysak, d�n��� tamamen durdur
                    if (Mathf.Abs(currentAngle - targetRotationAngle) < 0.1f)
                    {
                        currentRotationSpeedZ = 0f;
                        shouldStopAtTarget = false; // Art�k durdurmaya �al��m�yoruz
                    }
                }
            }

            // D�n�� h�z�n� Lerp ile yava�lat (sadece Z ekseninde)
            currentRotationSpeedZ = Mathf.Lerp(currentRotationSpeedZ, 0f, decelerationSpeed * Time.deltaTime);

            // Objenin Z ekseninde d�nmeye devam etmesi
            transform.Rotate(Vector3.forward, currentRotationSpeedZ, Space.World);
        }

        // Durdurmak i�in bo�luk tu�una bas�n
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStopAtTarget = true; // Hedef a��da durma i�lemini ba�lat
        }
    }
}
