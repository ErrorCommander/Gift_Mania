using Gameplay.ItemInfo;

namespace Gameplay.Interactive
{
    public class Box : GiftElement<BoxInfo>
    {
        protected override BoxInfo GetItem() => new(_elementColor);
    }
}