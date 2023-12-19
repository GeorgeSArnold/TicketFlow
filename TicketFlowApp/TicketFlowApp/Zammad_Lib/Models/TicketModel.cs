using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zammad_Lib.Models
{
    public class TicketModel : INotifyPropertyChanged
    {
        // props
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Created_at { get; set; }

        // article ids = (list<int>) > strings
        private List<int> _articleIds;
        public List<int> Article_ids
        {
            get { return _articleIds; }
            set
            {
                _articleIds = value;
                OnPropertyChanged(nameof(Article_ids));
                UpdateArticleIdsString();
            }
        }

        // list int > string
        private string _articleIdsString;
        public string ArticleIdsString
        {
            get { return _articleIdsString; }
            set
            {
                _articleIdsString = value;
                OnPropertyChanged(nameof(ArticleIdsString));
            }
        }

        // max article id
        private string _maxarticleIdsString;
        public string MaxArticleIdsString
        {
            get { return _maxarticleIdsString; }
            set
            {
                _maxarticleIdsString = value;
                OnPropertyChanged(nameof(MaxArticleIdsString));
            }
        }

        // const
        public TicketModel()
        {
            Article_ids = new List<int>();
            UpdateArticleIdsString();
            UpdateMaxArticleIdString();
        }

        // methods
        private void UpdateArticleIdsString()
        {
            ArticleIdsString = string.Join(", ", Article_ids);
        }
        private void UpdateMaxArticleIdString()
        {
            // Finde die höchste Artikel-ID aus der Liste
            int maxArticleId = Article_ids.Any() ? Article_ids.Max() : 0;
            MaxArticleIdsString = maxArticleId.ToString();  // Änderung hier
        }
        
        // eventh
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
