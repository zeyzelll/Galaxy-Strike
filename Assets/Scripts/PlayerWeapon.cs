using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
        // Hides the cursor (ibre)
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
            // var = değişken tanımlamak için kullanılır.
            // 2 lazeri birden açıp kapatmak için bu kodu kullanıyoruz.
        }
    }

    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    // nişangahın fare imlecinin konumuna göre hareket etmesini sağlar.
    // Input.mousePosition = fare imlecinin ekran üzerindeki konumunu alır.

    private void MoveTargetPoint()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
            //Bu kod parçası, lazerlerin hedef noktasına doğru dönmesini sağlar.
            //Birinci satırda, lazer konumunu hedef konumdan çıkarıyoruz, bu da bize lazer ile hedef nokta arasında bir vektör verecek.
            //İkinci satırda, bu vektöre bakacak bir dönüşüm oluşturuyoruz.
            //Üçüncü satırda, lazerin dönüşümünü bu yeni dönüşüme ayarlıyoruz.
            //Böylece lazerler her zaman hedef noktasına doğru bakacak.
        }
    }
}
