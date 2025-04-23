namespace _02.DOM.Models
{
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        private List<IHtmlElement> _elements;
        private Dictionary<string, string> _attributes;

        public HtmlElement()
        {
            this._elements = new List<IHtmlElement>();
            this._attributes = new Dictionary<string, string>();
        }

        public HtmlElement(ElementType type, params IHtmlElement[] children)
            : this()
        {
            this.Type = type;

            foreach (var child in children)
            {
                this._elements.Add(child);
                child.Parent = this;
            }
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children 
        { 
            get{ return this._elements; } 
            set{ this._elements = value; }
        }

        public Dictionary<string, string> Attributes 
        { 
            get { return this._attributes; } 
            set { this._attributes = value; } 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
