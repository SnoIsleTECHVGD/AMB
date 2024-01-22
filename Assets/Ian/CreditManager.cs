using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public Texture2D[] creditSlides;
    public RawImage rawImage;

    [SerializeField] private string titleScreenSceneName;

    private int currentSlide = 0;

    void Start()
    {
        if (rawImage == null)
        {
            rawImage = GetComponent<RawImage>();
            if (rawImage == null)
            {
                Debug.LogError("RawImage component not found. Make sure it's attached.");
                return;
            }
        }

        ShowSlide();
    }

    void ShowSlide()
    {
        if (creditSlides != null && creditSlides.Length > 0)
        {
            rawImage.texture = creditSlides[currentSlide];
        }
        else
        {
            Debug.LogError("Credit slides array is not properly set up.");
        }
    }

    public void NextSlide()
    {
        if (creditSlides != null && creditSlides.Length > 0)
        {
            currentSlide = (currentSlide + 1) % creditSlides.Length;
            ShowSlide();
        }
    }

    public void PreviousSlide()
    {
        if (creditSlides != null && creditSlides.Length > 0)
        {
            currentSlide = (currentSlide - 1 + creditSlides.Length) % creditSlides.Length;
            ShowSlide();
        }
    }

    public void GoToTitleScreen()
    {
        if (!string.IsNullOrEmpty(titleScreenSceneName))
        {
            SceneManager.LoadScene(titleScreenSceneName);
        }
        else
        {
            Debug.LogError("Title screen scene name is not set. Please assign a valid scene name in the inspector.");
        }
    }
}
