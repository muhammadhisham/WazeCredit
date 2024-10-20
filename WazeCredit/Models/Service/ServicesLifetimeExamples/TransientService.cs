namespace WazeCredit.Models.Service.ServicesLifetimeExamples
{
    public class TransientService
    {
        private readonly Guid _guid;
        public TransientService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()=> _guid;
    }
}
