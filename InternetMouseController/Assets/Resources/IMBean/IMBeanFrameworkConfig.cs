public class IMBeanFrameworkConfig
{
    public string GameObjectName;
    public IMEnumEvent EventName;
    public IMFacade2 Facade;
    public IMBeanFrameworkConfig(string gameObjectName, IMEnumEvent eventName, IMFacade2 facade)
    {
        this.GameObjectName = gameObjectName;
        this.EventName = eventName;
        this.Facade = facade;
    }
}
