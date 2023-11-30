using System;

namespace TankGame.Time 
{
    public class Timer
    {
        public event Action OnTimerEnds;

        private float timerDuration;

        private float currentTime;

        private bool decreaseTime;

        public float CurrentTime
        {
            get
            {
                return currentTime;
            }
        }

        public bool DecreaseTime
        {
            set
            {
                decreaseTime = value;
            }
            get
            {
                return decreaseTime;
            }
        }

        public float TimerDuration
        {
            set
            {
                timerDuration = value;

                currentTime = timerDuration;

                decreaseTime = false;
            }
            get
            {
                return timerDuration;
            }
        }

        public bool IsRunning
        {
            get 
            {
                return currentTime > 0.0f;
            }
        }

        public Timer(float timerDuration, bool decreaseTime, bool startFinished)
        {
            this.timerDuration = timerDuration;

            this.decreaseTime = decreaseTime;

            if (startFinished)
            {
                currentTime = 0.0f;
            }
            else 
            {
                currentTime = timerDuration;
            }
        }        

        public void UpdateTimer()
        {
            if (currentTime > 0.0f && decreaseTime)
            {
                currentTime -= UnityEngine.Time.deltaTime;

                if (currentTime <= 0.0f)
                {
                    currentTime = 0.0f;

                    OnTimerEnds?.Invoke();
                }
            }
        }

        public void ResetTime() 
        {
            currentTime = timerDuration;
        }
    }
}