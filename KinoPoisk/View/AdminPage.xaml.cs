using KinoPoisk.DB;
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

    private void LoadUsers()
    {
        //�� ���������� ���� xdxdxd
        UsersListView.ItemsSource = db.GetUsers().Where(u => u.Id != currentUser.Id).ToList();
    }

    private void Selected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedUser = e.SelectedItem as User;
    }

    private void Delete(object sender, EventArgs e)
    {
        if (selectedUser != null)
        {
            db.RemoveUser(selectedUser.Id);
            LoadUsers();
            DisplayAlert("�������", $"������������ {selectedUser.Login} �����", "��");
            selectedUser = null;
        }
        else
        {
            DisplayAlert("������", "�������� ������������ ��� ��������", "��");
        }
    }

    private async void AddContent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddContentPage());
    }

  
}
