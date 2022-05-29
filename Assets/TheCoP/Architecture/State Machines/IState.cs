namespace TheCoP.Architecture.State_Machines
{
    public interface IState
    {
        void Tick();
        void FixTick();
        void OnEnter();
        void OnExit();
    }
}
