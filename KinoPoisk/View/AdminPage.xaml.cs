using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Add;
using KinoPoisk.View.Update;
namespace KinoPoisk.View;
public partial class AdminPage : ContentPage
{
    private User currentUser;
    public AdminPage()
    {
        InitializeComponent();
        LoadUsers();
    }

    private async void LoadUsers()
    {
        //Не показываем себя xdxdxd
        var dbLocal = await DBALL.GetDB();
        var list = await dbLocal.GetUsers();
        UsersListView.ItemsSource = list.Where(u => u.Id != currentUser.Id).ToList();

    }

    private void Selected(object sender, SelectedItemChangedEventArgs e)
    {
        currentUser = e.SelectedItem as User;
    }

    private async void Delete(object sender, EventArgs e)
    {
        if (currentUser != null)
        {
            var dbLocal = await DBALL.GetDB();
            await dbLocal.RemoveUser(currentUser.Id);
            LoadUsers();
            await DisplayAlert("Удалено", $"Пользователь {currentUser.Login} удалён", "ОК");
            currentUser = null;
        }
        else
        {
            await DisplayAlert("Ошибка", "Выберите пользователя для удаления", "ОК");
        }
    }

    private async void AddContent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddContentPage());
    }

    private async void UpdateContent(object sender, EventArgs e)
    {
        var popup = new ListUpdateContentPopup(this);

        await this.ShowPopupAsync(popup);
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("currentUser", out object user))
        {
            currentUser = (User)user;
        }
    }
}
