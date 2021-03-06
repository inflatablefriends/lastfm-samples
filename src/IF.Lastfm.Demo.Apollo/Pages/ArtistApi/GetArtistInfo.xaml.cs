﻿using System;
using System.ComponentModel;
using IF.Lastfm.Demo.Apollo.ViewModels.ArtistApi;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IF.Lastfm.Demo.Apollo.Pages.ArtistApi
{
    public partial class GetArtistInfo : PhoneApplicationPage
    {
        private GetArtistInfoViewModel _viewModel;

        public GetArtistInfo()
        {
            _viewModel = new GetArtistInfoViewModel();

            DataContext = _viewModel;

            InitializeComponent();

            MultiApplicationBar.SelectedIndex = 0;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "InProgress")
            {
                if (_viewModel.InProgress)
                {
                    SystemTray.ProgressIndicator = new ProgressIndicator
                    {
                        IsVisible = _viewModel.InProgress,
                        IsIndeterminate = _viewModel.InProgress
                    };
                }
                else
                {
                    SystemTray.ProgressIndicator = null;
                }
            }
        }

        private void OnDoneClick(object sender, EventArgs e)
        {
            if (!_viewModel.InProgress)
            {
                _viewModel.GetInfo().AsAsyncAction();
            }
        }
    }
}