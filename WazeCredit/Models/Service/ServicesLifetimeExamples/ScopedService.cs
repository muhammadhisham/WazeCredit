namespace WazeCredit.Models.Service.ServicesLifetimeExamples
{
    public class ScopedService
    {
        private readonly Guid _guid;
        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()=> _guid;
    }
}
