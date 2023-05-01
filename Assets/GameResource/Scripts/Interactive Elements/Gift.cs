using Gameplay.ItemInfo;

namespace Gameplay.Interactive
{
    public class Gift : InteractiveMovableItem<GiftInfo>
    {
        protected override void RealiseItem(bool isTransferred)
        {
            
        }

        protected override GiftInfo GetItem()
        {
            var gift = new GiftInfo(new BoxInfo(ElementColor.Blue));
            gift.AddElement(new OrnamentInfo(ElementColor.Green));
            return gift;
        }
    }
}