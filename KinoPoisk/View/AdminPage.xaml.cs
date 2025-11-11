using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Add;
using KinoPoisk.View.Update;
namespace KinoPoisk.View;
public partial class AdminPage : ContentPage
{
    private User selectedUser;
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
        UsersListView.ItemsSource = list.Where(u => u.Id != User.GetUser().Id).ToList();

    }

    private void Selected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedUser = e.SelectedItem as User;
    }

    private async void Delete(object sender, EventArgs e)
    {
        if (selectedUser != null)
        {
            var dbLocal = await DBALL.GetDB();
            await dbLocal.RemoveUser(selectedUser.Id);
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
        await Navigation.PushAsync(new AddContentPage());
    }

    private async void UpdateContent(object sender, EventArgs e)
    {
        var popup = new ListUpdateContentPopup(this);

        await this.ShowPopupAsync(popup);
    }
}
