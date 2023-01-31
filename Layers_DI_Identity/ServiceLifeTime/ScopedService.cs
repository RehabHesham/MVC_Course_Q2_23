namespace Layers_DI_Identity.ServiceLifeTime
{
    public class ScopedService : IScopedService
    {
        public string Message { get; set; }
        public ScopedService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
}
