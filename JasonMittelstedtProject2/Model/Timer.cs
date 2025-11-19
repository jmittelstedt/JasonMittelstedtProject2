using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace JasonMittelstedtProject2.Model
{
    public class Timer
    {
        private readonly System.Timers.Timer timer;

        public int TotalSeconds { get; private set; }
        public int RemainingSeconds { get; private set; }

        public event Action<int>? Tick;        // Fires each second, sending remaining seconds
        public event Action? Completed;        // Fires when remaining reaches 0

        public Timer()
        {
            timer = new System.Timers.Timer(1000); // 1 second
            timer.Elapsed += OnTimerElapsed;
        }

        public void Start(int totalSeconds)
        {
            TotalSeconds = totalSeconds;
            RemainingSeconds = totalSeconds;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            RemainingSeconds--;

            Tick?.Invoke(RemainingSeconds);

            if (RemainingSeconds <= 0)
            {
                timer.Stop();
                Completed?.Invoke();
            }
        }
    }
}
