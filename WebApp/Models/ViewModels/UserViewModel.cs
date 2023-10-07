namespace WebApp.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public int CurrentRoomId { get; set; }
        public string CurrentRoomName { get; set; }
        public string Device { get; set; }
    }
}
