using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    // Tekerle�in d�n�� h�z�
    public float spinSpeed = 100f;

    // Tekerle�in duraca�� hedef a�� (X ekseni)
    public float targetAngle = 202.5f;

    // Tekerlek d�n�yor mu kontrol�
    private bool isSpinning = false;

    // �u anki a�� (X ekseni)
    private float currentAngle = 0f;

    // Y ve Z eksenlerindeki sabit a��lar
    private float fixedYAngle = -90f;
    private float fixedZAngle = -90f;

    void Update()
    {
        // Sol t�klama ile d�nmeye ba�lat
        if (Input.GetMouseButtonDown(0))
        {
            isSpinning = true;
        }

        // Sol t�klama b�rak�ld���nda otomatik d�nmeye ba�la
        if (Input.GetMouseButtonUp(0))
        {
            isSpinning = false;
            // Hedef a��ya ula�mak i�in kalan a��y� hesapla ve d�n�� h�z�n� ayarla
            float remainingAngle = targetAngle - currentAngle;
            spinSpeed = Mathf.Abs(remainingAngle) / 0.5f;
        }

        // Tekerlek d�n�yorsa
        if (isSpinning)
        {
            // �u anki a��y� g�ncelle
            currentAngle += spinSpeed * Time.deltaTime;

            // Tekerle�in rotasyonunu g�ncelle (X, Y, Z)
            transform.rotation = Quaternion.Euler(currentAngle, fixedYAngle, fixedZAngle);

            // Hedef a��ya yakla��ld�ysa d�nmeyi durdur
            if (Mathf.Abs(currentAngle - targetAngle) < 0.1f)
            {
                isSpinning = false;
                currentAngle = targetAngle;
            }
        }
    }
}