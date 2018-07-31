namespace Car_Services
{
    public class AddOwnerWindowViewModel : BaseViewModel
    {
        public AddOwnerWindowViewModel(IAdapter adapter)
        {
            _adapter = adapter;
            _createOwnerCmd = new Command(CreateOwner);
            NewOwner = new Owner();
        }

        public Owner NewOwner { get; set; }

        private IAdapter _adapter;
        private Command _createOwnerCmd;
        public Command CreateOwnerCmd
        {
            get { return _createOwnerCmd; }
        }
        public void CreateOwner()
        {
            _adapter.AddOwner(NewOwner);
            OnRequestClose();
        }
    }
}
