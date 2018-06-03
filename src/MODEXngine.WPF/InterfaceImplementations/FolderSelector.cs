using System;

using Microsoft.WindowsAPICodePack.Dialogs;

using MODEXngine.Interfaces;

using Xamarin.Forms;

[assembly: Dependency(typeof(MODEXngine.WPF.InterfaceImplementations.FolderSelector))]
namespace MODEXngine.WPF.InterfaceImplementations
{
    public class FolderSelector : IFolderSelector
    {
        public string SelectFolder()
        {
            var dlg = new CommonOpenFileDialog
            {
                Title = MODEXngine.lib.Common.Constants.NAME_APP,
                IsFolderPicker = true,
                InitialDirectory = AppContext.BaseDirectory,
                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                DefaultDirectory = AppContext.BaseDirectory,
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };

            return dlg.ShowDialog() == CommonFileDialogResult.Ok ? dlg.FileName : string.Empty;
        }
    }
}