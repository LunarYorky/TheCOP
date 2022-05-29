using UnityEngine.EventSystems;

public interface IStatsModifier : IEventSystemHandler
{
    void ModifyStatistics();
}
