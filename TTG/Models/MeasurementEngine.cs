using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TTG.ViewModels;

namespace TTG.Models
{
    public class MeasurementEngine : ViewModelBase
    {
        private MainSystem _mainSystem;
        private Thread _meaThread;
        private State _state;
        public MeasurementEngine(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
        }
        public void StartMeasurementEngine()
        {
            _state = _mainSystem.GetStateSystem();
            if (_state == State.ERROR || _state == State.NONE)
            {
                Log.Write(LogLevel.Error, "[MEA]Start Measurement Failed.");
                return;
            }
            _mainSystem.SetStateSystem(State.MEA);
            Log.Write(LogLevel.Info, "[MEA]Start Measurement.");
            _meaThread = new Thread(new ThreadStart(Run));
            _meaThread.Start();
        }
        public void Run()
        {
            _state = _mainSystem.GetStateSystem();
            if (_state == State.ERROR || _state == State.NONE)
            {
                Log.Write(LogLevel.Error, "[MEA]Start Measurement Failed.");
                return;
            }
            while (_state == State.MEA)
            {
                _state = _mainSystem.GetStateSystem();
                Console.WriteLine("Thread#{0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
            }
            StopMeasurementEngine();
        }
        public void StopMeasurementEngine()
        {
            if (_meaThread.IsAlive)
                _meaThread.Abort();

            Log.Write(LogLevel.Info, "[MEA]Stop Measurement.");
        }
    }
}
