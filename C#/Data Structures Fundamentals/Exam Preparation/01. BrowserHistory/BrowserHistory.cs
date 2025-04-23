namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();
        }

        public int Size => this.links.Count;

        public void Open(ILink link)
        {
            this.links.AddFirst(link);
        }

        public ILink GetByUrl(string url)
        {
            ILink link = this.GetLinkByUrlInsensitive(url);

            return link;
        }

        public bool Contains(ILink link)
        {
            return this.links.Contains(link);
        }

        public ILink LastVisited()
        {
            this.CheckEmptyCollection();

            return this.links.First.Value;
        }

        public ILink DeleteLast()
        {
            this.CheckEmptyCollection();

            ILink link = this.links.First.Value;
            this.links.RemoveFirst();

            return link;
        }

        public ILink DeleteFirst()
        {
            this.CheckEmptyCollection();

            ILink link = this.links.Last.Value;
            this.links.RemoveLast();

            return link;
        }

        public int RemoveLinks(string url)
        {
            this.CheckEmptyCollection();

            int cnt = 0;

            ILink link = this.GetByUrl(url);

            while (link != null)
            {
                this.links.Remove(link);
                cnt++;

                link = this.GetLinkByUrlInsensitive(url);
            }

            return cnt;
        }

        public void Clear()
        {
            this.links.Clear();
        }

        public ILink[] ToArray()
        {
            ILink[] links = this.GetLinksArray();

            return links;
        }
        
        public List<ILink> ToList()
        {
            List<ILink> links = this.GetLinksList();

            return links;
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var link in links)
                {
                    sb.AppendLine(link.ToString());
                }

                return sb.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private ILink GetLinkByUrlInsensitive(string url)
        {
            ILink link = null;

            foreach (var currentLink in this.links)
            {
                if (currentLink.Url.ToLower().Contains(url.ToLower()))
                {
                    link = currentLink;
                    break;
                }
            }

            return link;
        }

        private ILink[] GetLinksArray()
        {
            ILink[] links = new ILink[this.Size];

            int index = 0;

            foreach (var cueelink in this.links)
            {
                links[index++] = cueelink;
            }

            return links;
        }

        private List<ILink> GetLinksList()
        {
            List<ILink> links = new List<ILink>();

            foreach (var cueelink in this.links)
            {
                links.Add(cueelink);
            }

            return links;
        }

        private void CheckEmptyCollection()
        {
            if (0 == this.Size)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
