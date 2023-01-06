using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TTG.Models;
using static TTG.Models.MainSystem;

namespace TTG.ViewModels
{
    public class MainSectionViewModel : ViewModelBase
    {
        private string _stateText;
        public string StateText
        {
            get 
            { 
                return _stateText;
            }
            set 
            {
                if (_stateText != value)
                {
                    _stateText = value;
                    OnChanged("StateText");
                }
            }
        }
        public MainSectionViewModel()
        {
        }

        public void SetTextState(State state)
        {
            if (state == State.IDL)
            {
                StateText = "IDL";
            }
            else if(state == State.MEA)
            {
                StateText = "MEA";
            }
            else if (state == State.MANUAL)
            {
                StateText = "MANUAL";
            }
            else if (state == State.ENGINEERING)
            {
                StateText = "ENGINEERING";
            }
            else if (state == State.SIMUL)
            {
                StateText = "SIMUL";
            }
            else if (state == State.ERROR)
            {
                StateText = "ERROR";
            }
            else if (state == State.RESET)
            {
                StateText = "RESET";
            }
        }
    }
}
