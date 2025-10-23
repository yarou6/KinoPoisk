using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Add;
using KinoPoisk.View.Update;
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
        //�� ���������� ���� xdxdxd
        var dbLocal = await db.GetDB();
        var list = await dbLocal.GetUsers();
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
            var dbLocal = await db.GetDB();
            await dbLocal.RemoveUser(selectedUser.Id);
            LoadUsers();
            await DisplayAlert("�������", $"������������ {selectedUser.Login} �����", "��");
            selectedUser = null;
        }
        else
        {
            await DisplayAlert("������", "�������� ������������ ��� ��������", "��");
        }
    }

    private async void AddContent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddContentPage(db));
    }

    private async void UpdateContent(object sender, EventArgs e)
    {
        var popup = new ListUpdateContentPopup(db, this);

        await this.ShowPopupAsync(popup);
    }
}
