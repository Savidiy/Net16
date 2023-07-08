namespace MainModule
{
    public interface IWindowConfigProvider
    {
        WindowConfig GetConfig(WindowId windowId);
    }
}