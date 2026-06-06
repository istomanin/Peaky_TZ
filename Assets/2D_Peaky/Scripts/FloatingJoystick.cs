using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [SerializeField]
    private RectTransform joystickRoot;

    [SerializeField]
    private RectTransform background;

    [SerializeField]
    private RectTransform handle;

    [SerializeField]
    private float maxRadius = 100f;

    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        joystickRoot.gameObject.SetActive(false);
    }

    public void OnPointerDown(
        PointerEventData eventData)
    {
        joystickRoot.gameObject.SetActive(true);

        joystickRoot.position = eventData.position;

        background.position = eventData.position;

        handle.position = eventData.position;

        Direction = Vector2.zero;
    }

    public void OnDrag(
        PointerEventData eventData)
    {
        Vector2 startPosition =
            background.position;

        Vector2 offset =
            eventData.position - startPosition;

        offset = Vector2.ClampMagnitude(offset, maxRadius);

        handle.position = startPosition + offset;

        Direction = offset / maxRadius;
    }

    public void OnPointerUp(
        PointerEventData eventData)
    {
        Direction = Vector2.zero;

        joystickRoot.gameObject.SetActive(false);

        handle.localPosition = Vector3.zero;
    }
}