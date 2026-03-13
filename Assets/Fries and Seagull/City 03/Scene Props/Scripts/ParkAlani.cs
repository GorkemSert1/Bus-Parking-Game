using UnityEngine;

public class ParkAlani : MonoBehaviour
{
    [Header("Kazanma Ayarları")]
    public GameObject winUI;
    public BusControl busControlScript;

    [Header("Park Kuralları")]
    public float beklemeSuresi = 2f;
    private float suanBeklenenSure = 0f;

    [Header("Zorluk Ayarı (%90 Oturma)")]
    public float maksimumMesafe = 2.5f;
    public float maksimumAciSapmasi = 15f;

    private Collider parkCollider;

    void Start()
    {
        parkCollider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Otobus"))
        {
            // Otobüsün hızını, pozisyonunu ve SKORUNU almak için bileşenlerine erişiyoruz
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Collider otobusCollider = other.GetComponent<Collider>();
            CoinCollector otobusSkorKodu = other.GetComponent<CoinCollector>(); // Altın koduna eriştik!

            if (rb != null && otobusCollider != null && otobusSkorKodu != null)
            {
                // ŞART 1: OTOBÜS 100 ALTIN TOPLAMIŞ MI? (Toplamadıysa parkı reddet)
                if (otobusSkorKodu.skor < otobusSkorKodu.hedefSkor)
                {
                    suanBeklenenSure = 0f;
                    return; // Kodun geri kalanını okuma, direkt çık
                }

                // EĞER ALTIN TAMAMSA PARK KONTROLÜNE GEÇ
                Vector3 parkMerkez = parkCollider.bounds.center;
                Vector3 otobusMerkez = otobusCollider.bounds.center;
                parkMerkez.y = 0; otobusMerkez.y = 0;

                float mesafe = Vector3.Distance(parkMerkez, otobusMerkez);
                float aci = Quaternion.Angle(transform.rotation, other.transform.rotation);
                float hizalanma = Mathf.Min(aci, 180f - aci);

                // ŞART 2: HIZ, MESAFE VE AÇI UYGUN MU?
                if (rb.linearVelocity.magnitude < 0.1f && mesafe <= maksimumMesafe && hizalanma <= maksimumAciSapmasi)
                {
                    suanBeklenenSure += Time.deltaTime;

                    if (suanBeklenenSure >= beklemeSuresi)
                    {
                        ParkBasarili();
                    }
                }
                else
                {
                    suanBeklenenSure = 0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Otobus"))
        {
            suanBeklenenSure = 0f;
        }
    }

    void ParkBasarili()
    {
        if (winUI != null) winUI.SetActive(true);
        if (busControlScript != null) busControlScript.enabled = false;
        Debug.Log("GÖREV TAMAMLANDI! MÜKEMMEL PARK!");
    }
}