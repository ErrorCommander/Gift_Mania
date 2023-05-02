using Gameplay.ItemInfo;

namespace Gameplay.Interactive
{
    public class Ornament : GiftElement<OrnamentInfo>
    {
        protected override OrnamentInfo GetItem() => new(_elementColor);
    }
}