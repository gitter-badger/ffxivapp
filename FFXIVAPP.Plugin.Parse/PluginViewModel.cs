﻿// FFXIVAPP.Plugin.Parse
// PluginViewModel.cs
// 
// © 2013 Ryan Wilson

#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FFXIVAPP.Common.Events;

#endregion

namespace FFXIVAPP.Plugin.Parse
{
    public sealed class PluginViewModel : INotifyPropertyChanged
    {
        //used for global static properties

        public event EventHandler<PopupResultEvent> PopupResultChanged = delegate { };

        public void OnPopupResultChanged(PopupResultEvent e)
        {
            PopupResultChanged(this, e);
        }

        #region Property Bindings

        private static PluginViewModel _instance;
        private Dictionary<string, string> _locale;

        public static PluginViewModel Instance
        {
            get { return _instance ?? (_instance = new PluginViewModel()); }
        }

        public Dictionary<string, string> Locale
        {
            get { return _locale ?? (_locale = new Dictionary<string, string>()); }
            set
            {
                _locale = value;
                RaisePropertyChanged();
            }
        }

        public static Dictionary<string, string> PluginInfo
        {
            get
            {
                var pluginInfo = new Dictionary<string, string>();
                pluginInfo.Add("Icon", "Logo.png");
                pluginInfo.Add("Name", Common.Helpers.AssemblyHelper.Name);
                pluginInfo.Add("Description", Common.Helpers.AssemblyHelper.Description);
                pluginInfo.Add("Copyright", Common.Helpers.AssemblyHelper.Copyright);
                pluginInfo.Add("Version", Common.Helpers.AssemblyHelper.Version.ToString());
                return pluginInfo;
            }
        }

        #endregion

        #region Declarations

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}