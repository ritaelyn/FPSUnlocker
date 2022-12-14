using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#if !TORCH

namespace Shared.Config
{
    public class PluginConfig: IPluginConfig
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetValue<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;

            OnPropertyChanged(propName);
        }

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;

            propertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private bool enabled = true;
        private int framerateCap = 500;
        // TODO: Implement your config fields

        public bool Enabled
        {
            get => enabled;
            set => SetValue(ref enabled, value);
        }

        // TODO: Encapsulate them as properties
        public int FramerateCap
        {
            get => framerateCap;
            set => SetValue(ref framerateCap, value);
        }
    }
}

#endif