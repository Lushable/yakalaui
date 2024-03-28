using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _project.Runtime.Project.UI.Scripts.View
{
    public class GameScreenView : MonoBehaviour
    {
        public Image clickImage; // Image'i sürükleyip bırakarak atanacak
        public float clickDuration = 1f; // Tıklama efektinin süresi

        bool canClick = true; // Tıklamaya izin vermek için kontrol değişkeni

        void Start()
        {
            // Oyun başladığında Image'i devre dışı bırak
            clickImage.gameObject.SetActive(false);
        }

        void Update()
        {
            // Her güncellemede fare tıklamasını kontrol et
            if (Input.GetMouseButtonDown(0) && canClick)
            {
                // Fare tıklaması algılandığında
                Vector3 clickPosition = transform.position; // Image'in pozisyonunu al

                // Image'i tıklama konumuna taşı
                clickImage.rectTransform.position = clickPosition;

                // Image'i etkinleştir
                clickImage.gameObject.SetActive(true);

                // Tıklamayı işleme koy
                StartCoroutine(DisableClickEffect());
            }
        }

        IEnumerator DisableClickEffect()
        {
            // Tıklama efektinin belirli bir süre sonra devre dışı bırakılması
            canClick = false; // Yeni tıklamalara izin verme
            yield return new WaitForSeconds(clickDuration);
            clickImage.gameObject.SetActive(false); // Image'i devre dışı bırak
            canClick = true; // Yeniden tıklamalara izin ver
        }
    }
}
