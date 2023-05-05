using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay
{
    public class ApplyElementSettings : MonoBehaviour
    {
        [SerializeField] private GiftElement _giftElement;
        [SerializeField] private ElementColor _elementColor = ElementColor.Blue;
        [SerializeField] private Transform[] _changeActiveObjects;

        private void Awake()
        {
            switch (_giftElement)
            {
                case GiftElement.Box:
                    BoxesChange();
                    return;
                case GiftElement.Bow:
                    BowsChange();
                    return;
                case GiftElement.Ornament:
                    OrnamentsChange();
                    return;
            }
        }

        private void BoxesChange()
        {
            switch (_elementColor)
            {
                case ElementColor.Blue:
                    SetActiveObjects(GameMode.CurrentSettings.BlueBox);
                    return;
                case ElementColor.Red:
                    SetActiveObjects(GameMode.CurrentSettings.RedBox);
                    return;
                case ElementColor.Green:
                    SetActiveObjects(GameMode.CurrentSettings.GreenBox);
                    return;
            }
        }

        private void BowsChange()
        {
            switch (_elementColor)
            {
                case ElementColor.Blue:
                    SetActiveObjects(GameMode.CurrentSettings.BlueBow);
                    return;
                case ElementColor.Red:
                    SetActiveObjects(GameMode.CurrentSettings.RedBow);
                    return;
                case ElementColor.Green:
                    SetActiveObjects(GameMode.CurrentSettings.GreenBow);
                    return;
            }
        }

        private void OrnamentsChange()
        {
            switch (_elementColor)
            {
                case ElementColor.Blue:
                    SetActiveObjects(GameMode.CurrentSettings.BlueOrnament);
                    return;
                case ElementColor.Red:
                    SetActiveObjects(GameMode.CurrentSettings.RedOrnament);
                    return;
                case ElementColor.Green:
                    SetActiveObjects(GameMode.CurrentSettings.GreenOrnament);
                    return;
            }
        }

        private void SetActiveObjects(bool state)
        {
            foreach (var activeObject in _changeActiveObjects)
            {
                activeObject.gameObject.SetActive(state);
            }
        }

        private enum GiftElement
        {
            Box,
            Bow,
            Ornament
        }
    }
}
