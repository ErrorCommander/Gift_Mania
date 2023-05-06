namespace Gameplay
{
    internal interface IViewer<in TValue>
    {
        public void SetSprite(TValue value);
    }
}