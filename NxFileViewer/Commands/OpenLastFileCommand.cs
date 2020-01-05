﻿using System;
using System.IO;
using Emignatik.NxFileViewer.Services;
using Emignatik.NxFileViewer.Settings;

namespace Emignatik.NxFileViewer.Commands
{
    public class OpenLastFileCommand : CommandBase
    {
        private readonly SupportedFilesOpenerService _supportedFilesOpenerService;

        public OpenLastFileCommand(SupportedFilesOpenerService supportedFilesOpenerService)
        {
            _supportedFilesOpenerService = supportedFilesOpenerService ?? throw new ArgumentNullException(nameof(supportedFilesOpenerService));
        }

        public override void Execute(object parameter)
        {
            var lastOpenedFile = AppSettings.Default.LastOpenedFile;
            if (lastOpenedFile != null && File.Exists(lastOpenedFile))
            {
                _supportedFilesOpenerService.OpenFile(lastOpenedFile);
            }

        }
    }
}
