

using System;
using System.IO;

namespace CallFileProcessor
{
    public interface IFileWatcher
    {
        void StartFileWatcher();
    }

    public class FileWatcher : IFileWatcher
    {
        private readonly ICallRecordProcessor _callRecordProcessor;
        private readonly FileSystemWatcher _fileWatcher;
        private readonly string _sourceFolderPath;

        public FileWatcher(ICallRecordProcessor callRecordProcessor, string sourceFolderPath)
        {
            _callRecordProcessor = callRecordProcessor ?? throw new ArgumentNullException(nameof(callRecordProcessor));
            _sourceFolderPath = sourceFolderPath;

            _fileWatcher = new FileSystemWatcher
            {
                Path = _sourceFolderPath,
                Filter = "*.*",
                EnableRaisingEvents = true
            };
            _fileWatcher.Created += OnFileCreated;
        }

        public void StartFileWatcher()
        {
            //_fileWatcher.EnableRaisingEvents = true;
        }

        private async void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            string sourceFilePath = e.FullPath;
            await _callRecordProcessor.ProcessFileAsync(sourceFilePath);
        }
    }
}
