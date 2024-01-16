using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public Texture2D[] creditSlides;
    public RawImage rawImage;
    private int currentSlide = 0;

    [SerializeField] private Object titleScreenScene; // Scene asset for the title screen

    void Start()
    {
        if (rawImage != null)
        {
            ShowSlide(currentSlide);
        }
        else
        {
            Debug.LogError("RawImage component not found. Make sure it's attached.");
        }
    }

    void ShowSlide(int index)
    {
        if (rawImage != null && creditSlides != null && creditSlides.Length > 0)
        {
            // Set the texture of the Raw Image to the current slide
            rawImage.texture = creditSlides[index];
        }
        else
        {
            Debug.LogError("RawImage component, creditSlides array, or creditSlides length is not properly set up.");
        }
    }

    public void NextSlide()
    {
        if (creditSlides != null && creditSlides.Length > 0)
        {
            currentSlide = (currentSlide + 1) % creditSlides.Length;
            ShowSlide(currentSlide);
        }
    }

    public void PreviousSlide()
    {
        if (creditSlides != null && creditSlides.Length > 0)
        {
            currentSlide = (currentSlide - 1 + creditSlides.Length) % creditSlides.Length;
            ShowSlide(currentSlide);
        }
    }

    public void GoToTitleScreen()
    {
        if (titleScreenScene != null && titleScreenScene is SceneAsset)
        {
            string scenePath = AssetDatabase.GetAssetPath(titleScreenScene);
            SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);

            if (sceneAsset != null)
            {
                SceneManager.LoadScene(sceneAsset.name);
            }
            else
            {
                Debug.LogError("Invalid scene asset selected. Make sure it's a valid scene asset.");
            }
        }
        else
        {
            Debug.LogError("Title screen scene asset not set. Please assign a valid scene asset in the inspector.");
        }
    }
}
