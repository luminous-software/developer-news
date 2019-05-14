//using GalaSoft.MvvmLight.Command;
//using System;

//namespace DeveloperNews.UI.Commands
//{
//    public class ClickCommand : RelayCommand<string>
//    {
//        private readonly Action<string> _action;
//        private readonly bool _canExecute;

//        public ClickCommand(Action<string> action, bool canExecute)
//        {
//            _action = action;
//            _canExecute = canExecute;
//        }

//        public ClickCommand()
//        { }

//        public bool CanExecute()
//            => _canExecute;

//        public void Execute(string parameter)
//            => _action(parameter);
//    }
//}
