namespace Gameplay.ItemInfo
{
    public abstract class ElementInfo : BaseItemInfo
    {
        public ElementColor ElementColor => _color;
        
        private ElementColor _color;

        public ElementInfo(ElementColor color) => _color = color;
    }
}