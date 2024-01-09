using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DynamicData;
using RLab5.Repository;
using RLab5.Database;
using RLab5.Models;
using ReactiveUI;

namespace RLab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly RContext _context;
    private readonly IRRepository _repository;
    private string _inputWord;
    private bool _isInputValid;
    
    public MainWindowViewModel()
    {
        _context = new RContext();
        _repository = new RRepository(_context);
        var t = _repository.LoadFromDb();
        ContactList.AddRange(t);
        ContactList = new ObservableCollection<ContactDto>(_repository.LoadFromDb());
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    private string _surname;
    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    
    private string _phone;
    public string Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    
    private string _email;
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }
    
    
    private ContactDto _selectedItem;
    public ContactDto SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedItem, value);
            if (value != null)
            {
                Name = SelectedItem.Name;
                Surname = SelectedItem.Surname;
                Email = SelectedItem.Email;
                Phone = SelectedItem.Phone;
            }
        }
    }
    
    public ObservableCollection<ContactDto> ContactList { get; set; } = [];
    
    public void AddContact()
    {

        Name = "";
        Surname = "";
        Phone = "";
        Email = "";
        SelectedItem = null;
    }
    
    
    public async void SaveChanges()
    {
        await Task.Delay(1000);
        if (SelectedItem == null)
        {
            var newContact = new ContactDto
            {
                Name = Name,
                Surname =Surname,
                Phone = Phone,
                Email = Email
            };
            ContactList.Add(newContact);
        }
        else
        {
            foreach (var contact in ContactList)
            {
                if (contact.Phone != SelectedItem.Phone) continue;
                contact.Name = Name;
                contact.Surname = Surname;
                contact.Phone = Phone;
                contact.Email = Email;
            }
        }
        _repository.SaveToDb(ContactList);

    }
    
    
}
