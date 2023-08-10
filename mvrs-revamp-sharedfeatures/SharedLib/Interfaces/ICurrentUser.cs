using Models.ViewModels.Identity;

namespace SharedLib.Interfaces
{
    public interface ICurrentUser
    {
        public VwUser VwUser { get; set; }
    }
}
