public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public GameEventController<int> WoodAmountChanged { get; private set; }
    public GameEventController<int> StoneAmountChanged { get; private set; }

    public EventService()
    {
        WoodAmountChanged = new GameEventController<int>();
        StoneAmountChanged = new GameEventController<int>();
    }
}
