using CSIT.ZB.Apps.DataModels.Entities;

namespace CSIT.ZB.Apps.ServiceModels.Services
{
    public class CurrentUserService
    {
        private User? _currentUser;
        private bool _isGuestUser = false;

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            _isGuestUser = false;
        }

        public void SetGuestUser()
        {
            _isGuestUser = true;
            _currentUser = null; // Reset the current user
        }

        public int GetCurrentUserId()
        {
            return _currentUser?.Id ?? 0;
        }

        public bool IsUserLoggedIn()
        {
            return _currentUser != null;
        }

        public bool IsGuestUser()
        {
            return _isGuestUser;
        }
    }
}
