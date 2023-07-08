namespace MainModule
{
    public interface IStateWithPayload<in T>
    {
        void Enter(T payload);
    }
}