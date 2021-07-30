using UnityEngine;
public class ObjectRenderSwitcher : MonoBehaviour
{
    [SerializeField] GameObject spriteView;
    [SerializeField] GameObject primitivesView;

    private void Start()
    {
        // Subscribing from the notification about the change of the render type
        ApplicationData.Instance.ChangeRenderingType += SetRenderView;

        SetRenderView();
    }

    private void OnDestroy()
    {
        // Unsubscribing from the notification about the change of the render type
        ApplicationData.Instance.ChangeRenderingType -= SetRenderView;
    }

    // Setting the render type
    private void SetRenderView()
    {
        switch (ApplicationData.Instance.RenderingType)
        {
            case RenderingType.Sprites:
                spriteView.SetActive(true);
                primitivesView.SetActive(false);
                break;
            case RenderingType.Primitives:
                spriteView.SetActive(false);
                primitivesView.SetActive(true);
                break;
        }
    }
}
