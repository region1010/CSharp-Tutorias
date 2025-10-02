#region using
using static System.Math;
#endregion

#region namespace
namespace TeleprompterConsole;
#endregion

internal class TelePrompterConfig
{
    public int DelayInMilliseconds { get; private set; } = 200;

    public void UpdateDelay(int increment) // negative to speed up
    {
        var newDelay = Min(DelayInMilliseconds + increment, 1000);
        newDelay = Max(newDelay, 20);
        DelayInMilliseconds = newDelay;
    }

    public bool Done { get; private set; }

    public void SetDone()
    {
        Done = true;
    }
}