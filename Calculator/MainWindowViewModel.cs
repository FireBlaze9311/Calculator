using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    class MainWindowViewModel:BaseViewModel
    {
        public DelegateCommand OperatorCommand { get; set; }
        public DelegateCommand EqualsCommand { get; set; }

        public DelegateCommand NumberCommand { get; set; }
        public MainWindowViewModel()
        {
            NumberCommand = new DelegateCommand((n) => {
                byte val = byte.Parse((string)n);
                CurrentValue = CurrentValue * 10 + val;
            });

            OperatorCommand = new DelegateCommand((op) =>
            {
                lastvalue = CurrentValue;
                CurrentValue = 0;
                this.op = char.Parse((string)op);
            });

            EqualsCommand = new DelegateCommand((o) =>
            {
                long res=lastvalue;
                switch (op)
                {
                    case '+':
                        res += CurrentValue;
                        break;
                    case '-':
                        res -= CurrentValue;
                        break;
                    case '/':
                        res /= CurrentValue;
                        break;
                    case '*':
                        res *= CurrentValue;
                        break;
                }
                CurrentValue = res;
            });
        }

        long _currentValue;
        public long CurrentValue
        {
            get => _currentValue;
            set => SetProperty(ref _currentValue, value);
        }

        long lastvalue;

        char op;
    }
}
