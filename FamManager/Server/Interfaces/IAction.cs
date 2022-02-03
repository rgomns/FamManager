using FamManager.Shared.Models;
namespace FamManager.Server.Interfaces
{
    public interface IAction
    {
        public List<Shared.Models.Action> GetAction();
        public void AddAction(Shared.Models.Action action);
        public void UpdateAction(Shared.Models.Action action);
        public Shared.Models.Action GetAction(Guid Id);
        public void DeleteAction(Guid Id);
    }
}
