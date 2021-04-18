using System;
using UnityEngine;
using Type = System.Type;

namespace SeparateButTogether.Variables
{
    /// <summary>
    /// Used as a base for the scriptable object variables.
    /// </summary>
    /// <typeparam name="T">Data type of the variable.</typeparam>
    public class BaseVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        // We can provide a description of what this variable does.
        [Multiline]
        public string developerDescription = "";
#endif

        // When this value changes we call an event.
        public event Action<T> OnChange;
        
        public T Value
        {
            get => _value;
            set { 
                _value = SetValue(value);
                OnChange?.Invoke(value);
            }
        }

        public Type Type => typeof(T);

        public object BaseValue
        {
            get => _value;
            set => _value = SetValue((T)value);
        }

        [SerializeField] private T _value = default(T);

        public T SetValue(BaseVariable<T> value)
        {
            return SetValue(value.Value);
        }

        public T SetValue(T value)
        {
            _value = value;
            return value;
        }

        public override string ToString()
        {
            return _value == null ? "null" : _value.ToString();
        }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    }
}
