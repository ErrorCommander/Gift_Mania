using Gameplay.ItemInfo;

namespace Gameplay.Interactive
{
    public class Bow : GiftElement<BowInfo>
    {
        protected override BowInfo GetItem() => new(_elementColor);
    }
}