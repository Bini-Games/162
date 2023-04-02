using System;

namespace Gameplay
{
    public class GameplayScore
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                OnValueChanged?.Invoke(value);
                _value = value;
            }
        }

        public event Action<int> OnValueChanged;
    }
}