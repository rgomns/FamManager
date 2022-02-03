using FamManager.Server.Interfaces;
using FamManager.Server.Models;
using FamManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FamManager.Server.Services
{
    public class ActionManager : IAction
    {
        readonly DatabaseContext _dbContext = new();
        public ActionManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<Shared.Models.Action> GetAction()
        {
            try
            {
                return _dbContext.Actions.ToList();
            }
            catch
            {
                throw;
            }
        }
        
        public void AddAction(Shared.Models.Action action)
        {
            try
            {
                _dbContext.Actions.Add(action);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateAction(Shared.Models.Action action)
        {
            try
            {
                _dbContext.Entry(action).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        
        public Shared.Models.Action GetAction(Guid id)
        {
            try
            {
                Shared.Models.Action? action = _dbContext.Actions.Find(id);
                if (action != null)
                {
                    return action;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        
        public void DeleteAction(Guid id)
        {
            try
            {
                Shared.Models.Action? action = _dbContext.Actions.Find(id);
                if (action  != null)
                {
                    _dbContext.Actions.Remove(action);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}