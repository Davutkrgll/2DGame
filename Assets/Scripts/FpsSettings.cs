using UnityEngine;

public class FpsSettings : MonoBehaviour
{
     void Start()
    {
        // İstediğiniz FPS sınırını buraya yazabilirsiniz. Örneğin, 60 FPS:
        Application.targetFrameRate = 120;

        // VSync'i kapatarak FPS sınırının çalışmasını sağlayın (Opsiyonel)
        QualitySettings.vSyncCount = 0;
    }

    void Update()
    {
        // FPS'i dinamik olarak güncellemek isterseniz buraya ek kod yazabilirsiniz.
    }
}
