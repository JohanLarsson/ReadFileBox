namespace ReadFileBox
{
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using ReadFileBox.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private string _content;
        private static readonly string FileName = @"C:\Temp\SampleFile.txt";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Content
        {
            get { return _content; }
            set
            {
                if (value == _content) return;
                _content = value;
                OnPropertyChanged();
            }
        }

        public async Task Read()
        {
            using (var stream = File.OpenRead(FileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    Content = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task Save()
        {
            using (var stream = File.OpenWrite(FileName))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(Content).ConfigureAwait(false);
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
