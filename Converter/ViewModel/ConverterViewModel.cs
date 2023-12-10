using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Converter.ViewModel
{
    internal class ConverterViewModel : INotifyPropertyChanged
    {

        public double numberin;
        public double numberout;




        public double RUB_USD = 91.60;
        public double RUB_CNY= 12.79;
        public double USD_CNY = 7.17;

        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand ConverteCommand { get; set; }
        public int pikcer1, pikcer2;



        public ConverterViewModel()
        {
            ConverteCommand = new Command(() =>
            {
                if (Picker1 == 0 && Picker2 == 1)
                {
                    NumberOUT = NumberIN / RUB_USD;
                }
                else if (Picker1 == 0 && Picker2 == 0)
                {
                    NumberOUT = NumberIN;
                }
                else if (Picker1 == 1 && Picker2 == 0)
                {
                    NumberOUT = NumberIN * RUB_USD;
                }
                else if (Picker1 == 1 && Picker2 == 1)
                {
                    NumberOUT = NumberIN;
                }
                else if (Picker1 == 0 && Picker2 == 2)
                {
                    NumberOUT = NumberIN / RUB_CNY;
                }
                else if (Picker1 == 2 && Picker2 == 2)
                {
                    NumberOUT = NumberIN;
                }
                else if(Picker1 == 2 && Picker2 == 0)
                {
                    NumberOUT = NumberIN * RUB_CNY;
                }else if(Picker1 == 1 && Picker2 == 2)
                {
                    NumberOUT = NumberIN * USD_CNY;
                }else if(Picker1 == 2 && Picker2 == 1)
                {
                    NumberOUT = NumberIN / USD_CNY;
                }
            });
        }

        public int Picker1
        {
            get => pikcer1;
            set
            {
                if( pikcer1 != value )
                {
                    pikcer1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Picker2
        {
            get => pikcer2;
            set
            {
                if (pikcer2 != value)
                {
                    pikcer2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public double NumberIN { 
            get => numberin;
            set
            {
                if(numberin != value)
                {        
                    numberin = value;
                    OnPropertyChanged();
                }    
            }
        }
        public double NumberOUT { get => numberout;
            set {
                    numberout = value;
                    OnPropertyChanged();
            } 
        }

       

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
