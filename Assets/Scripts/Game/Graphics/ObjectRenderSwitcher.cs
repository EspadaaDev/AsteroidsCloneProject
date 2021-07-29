using UnityEngine;
public class ObjectRenderSwitcher : MonoBehaviour
{
    [SerializeField] GameObject spriteView;
    [SerializeField] GameObject primitivesView;

    private void Start()
    {
        ApplicationData.Instance.ChangeRenderingType += SetRenderView;
        SetRenderView();
    }

    private void SetRenderView()
    {
        switch (ApplicationData.Instance.RenderingType)
        {
            case RenderingType.Sprite:
                spriteView.SetActive(true);
                primitivesView.SetActive(false);
                break;
            case RenderingType.Primitives:
                spriteView.SetActive(true);
                primitivesView.SetActive(false);
                break;
        }
    }
}
