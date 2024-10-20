namespace WazeCredit.Models.Service.ServicesLifetimeExamples
{
    public class SingletonService
    {
        private readonly Guid _guid;
        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()=> _guid;
    }
}
