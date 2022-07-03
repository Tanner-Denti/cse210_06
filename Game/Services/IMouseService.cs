using System.Numerics;


namespace cse210_06.Game.Services
{
    public interface IMouseService
    {
        Vector2 GetCoordinates();
        bool IsButtonDown(MouseButton button);
        bool IsButtonPressed(MouseButton button);
        bool IsButtonReleased(MouseButton button);
        bool IsButtonUp(MouseButton button);
    }
}