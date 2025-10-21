using KinoPoisk.DB;
using System.Threading.Tasks;
namespace KinoPoisk.View;
public partial class AdminPage : ContentPage
{
    private DBALL db;
    private User currentUser;
    private User selectedUser;
    public AdminPage(DBALL database, User user)
    {
        InitializeComponent();
        db = database;
        currentUser = user;
        LoadUsers();
    }

    private async void LoadUsers()
    {
        //Не показываем себя xdxdxd
        var list = await db.GetDB().Result.GetUsers();
        UsersListView.ItemsSource = list.Where(u => u.Id != currentUser.Id).ToList();

    }

    private void Selected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedUser = e.SelectedItem as User;
    }

    private async void Delete(object sender, EventArgs e)
    {
        if (selectedUser != null)
        {
            await db.GetDB().Result.RemoveUser(selectedUser.Id);
            LoadUsers();
            await DisplayAlert("Удалено", $"Пользователь {selectedUser.Login} удалён", "ОК");
            selectedUser = null;
        }
        else
        {
            await DisplayAlert("Ошибка", "Выберите пользователя для удаления", "ОК");
        }
    }

    private async void AddContent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddContentPage(db));
    }

  
}
