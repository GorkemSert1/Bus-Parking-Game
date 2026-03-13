using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [Header("Oyun Sonu Ayarlarý")]
    public GameObject gameOverUI;
    public BusControl busControlScript;

    private void OnCollisionEnter(Collision collision)
    {
        // 1. DURUM: Çarptýðýmýz obje "Engel" ise (Araba, durak vb.) oyunu bitir
        if (collision.gameObject.CompareTag("Engel"))
        {
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }

            if (busControlScript != null)
            {
                busControlScript.enabled = false;
            }
            Debug.Log("ENGELE ÇARPILDI! OYUN BÝTTÝ.");
        }

        // 2. DURUM: Çarptýðýmýz obje "Agac" ise onu yok et
        else if (collision.gameObject.CompareTag("Agac"))
        {
            Destroy(collision.gameObject); // Aðacý haritadan sil
            Debug.Log("AÐAÇ YOK EDÝLDÝ!");
        }
    }
}