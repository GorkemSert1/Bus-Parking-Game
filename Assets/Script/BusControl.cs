using UnityEngine;

public class BusControl : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    public float moveSpeed = 15f;
    public float turnSpeed = 100f; // Velocity ile d�n��te bu say�n�n biraz daha b�y�k olmas� gerekebilir

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // 1. �LER� / GER� HAREKET (Saf �vme)
        // Modelimiz ters oldu�u i�in y�n� yine eksi (-) ile ayarl�yoruz
        Vector3 ileriYonu = -transform.forward * moveInput * moveSpeed;

        // Yer�ekimini (a�a�� d��me h�z�n�) bozmamak i�in Y eksenindeki h�z� koruyoruz
        rb.linearVelocity = new Vector3(ileriYonu.x, rb.linearVelocity.y, ileriYonu.z);

        // 2. SA�A / SOLA D�N�� (A��sal �vme)
        if (moveInput != 0)
        {
            float donusYonu = turnInput * turnSpeed * Mathf.Sign(moveInput);
            // D�n�� h�z�n� fizik motoruna (Angular Velocity) veriyoruz
            rb.angularVelocity = new Vector3(0f, donusYonu * Mathf.Deg2Rad, 0f);
        }
        else
        {
            // Tu�a basmay� b�rak�nca otob�s�n kendi etraf�nda d�nmesini an�nda durdur
            rb.angularVelocity = Vector3.zero;
        }
    }
}