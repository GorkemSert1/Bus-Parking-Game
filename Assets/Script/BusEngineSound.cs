using UnityEngine;

public class BusEngineSound : MonoBehaviour
{
    [Header("Ses Ayarlarý")]
    public AudioSource motorSesi; // Otobüsün üzerindeki Audio Source

    [Header("Devir (Pitch) Ayarlarý")]
    public float rolantiPitch = 0.8f; // Otobüs dururkenki tok motor sesi
    public float gazPitch = 1.5f;     // Gaza basarkenki baðýran motor sesi
    public float tepkiHizi = 3f;      // Sesin deðiþme hýzý (Gaza basýnca aniden mi baðýrsýn, yavaþ yavaþ mý?)

    void Start()
    {
        // Oyun baþladýðýnda ses rölantide baþlasýn
        if (motorSesi != null)
        {
            motorSesi.pitch = rolantiPitch;
            motorSesi.Play();
        }
    }

    void Update()
    {
        // Eðer ses kaynaðý yoksa hata vermemesi için kodu durdur
        if (motorSesi == null) return;

        // W veya S tuþuna basýlýp basýlmadýðýný kontrol et (0 ile 1 arasý bir deðer alýr)
        // Mathf.Abs kullanýyoruz çünkü S'ye basýnca çýkan eksi (-) deðeri de artýya çevirmemiz lazým
        float gazGirdisi = Mathf.Abs(Input.GetAxis("Vertical"));

        // Tuþa basýlma durumuna göre hedef motor devrini (pitch) hesapla
        float hedefPitch = Mathf.Lerp(rolantiPitch, gazPitch, gazGirdisi);

        // Mevcut sesi, hesaplanan hedef sese doðru yumuþakça (akýcý bir þekilde) deðiþtir
        motorSesi.pitch = Mathf.Lerp(motorSesi.pitch, hedefPitch, Time.deltaTime * tepkiHizi);
    }
}