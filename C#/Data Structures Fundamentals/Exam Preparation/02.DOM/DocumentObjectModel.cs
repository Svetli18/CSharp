namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        private Dictionary<ElementType, List<IHtmlElement>> elements;

        public DocumentObjectModel()
        {
            this.elements = new Dictionary<ElementType, List<IHtmlElement>>();
        }

        public DocumentObjectModel(IHtmlElement root)
            :this()
        {
            this.Root = root;
            this.DfsInsetElementsInData(this.Root);
        }

        private void DfsInsetElementsInData(IHtmlElement subtree)
        {
            if (!this.elements.ContainsKey(subtree.Type))
            {
                this.elements[subtree.Type] = new List<IHtmlElement>();
            }

            if (this.elements.ContainsKey(subtree.Type))
            {
                this.elements[subtree.Type].Add(subtree);
            }

            foreach (var child in subtree.Children)
            {
                this.DfsInsetElementsInData(child);
            }

        }

        public IHtmlElement Root { get; private set; }

        public bool Contains(IHtmlElement htmlElement)
        {
            bool result = this.DfsCheckHtmlExist(this.Root, htmlElement);

            return result;
        }

        public IHtmlElement GetElementByType(ElementType type)
        {
            IHtmlElement element = this.BfsGetElementByType(this.Root, type);

            return element;
        }
                
        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            List<IHtmlElement> elements = new List<IHtmlElement>();

            this.DfsGetElementsByType(this.Root, elements, type);

            return elements;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement parentElement = this.DfsGetHtmlElement(this.Root, parent);

            this.ValidateElementIsNotNull(parentElement);

            parentElement.Children.Insert(0, child);
            child.Parent = parentElement;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement parentElement = this.DfsGetHtmlElement(this.Root, parent);

            this.ValidateElementIsNotNull(parentElement);

            parentElement.Children.Add(child);
            child.Parent = parentElement;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            IHtmlElement elementForRemove = this.DfsGetHtmlElement(this.Root, htmlElement);

            this.ValidateElementIsNotNull(elementForRemove);

            if (this.Root.Equals(elementForRemove))
            {
                this.Root = null;
            }
            else
            {
                IHtmlElement parent = elementForRemove.Parent;
                parent.Children.Remove(elementForRemove);
                elementForRemove.Parent = null;
            }

        }

        public void RemoveAll(ElementType elementType)
        {
            List<IHtmlElement> elements = new List<IHtmlElement>();
            this.DfsGetElementsByType(this.Root, elements, elementType);

            for (int i = 0; i < elements.Count; i++)
            {
                IHtmlElement parent = elements[i].Parent;

                if (parent != null)
                {
                    parent.Children.Remove(elements[i]);
                }

                elements[i].Children.Clear();
                elements[i].Parent = null;
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IHtmlElement element = this.DfsGetHtmlElement(this.Root, htmlElement);

            this.ValidateElementIsNotNull(element);

            if (element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IHtmlElement element = this.DfsGetHtmlElement(this.Root, htmlElement);

            this.ValidateElementIsNotNull(element);

            if (!element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Remove(attrKey);

            return true;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            IHtmlElement htmlElement = this.BfsGetElementById(this.Root, idValue);

            return htmlElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.DfsGetRootAsString(this.Root, sb, 0);

            return sb.ToString().Trim();
        }

        private IHtmlElement BfsGetElementById(IHtmlElement root, string idValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(root);

            while (0 < queue.Count)
            {
                IHtmlElement currElement = queue.Dequeue();

                if (currElement.Attributes.ContainsValue(idValue))
                {
                    return currElement;
                }

                foreach (var child in currElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private IHtmlElement BfsGetElementByType(IHtmlElement root, ElementType type)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(root);

            while (0 < queue.Count)
            {
                IHtmlElement currElement = queue.Dequeue();

                if (currElement.Type.Equals(type))
                {
                    return currElement;
                }

                foreach (var child in currElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private IHtmlElement DfsGetElementById(IHtmlElement subtree, string idValue)
        {
            IHtmlElement element = null;

            if (subtree.Attributes.ContainsValue(idValue))
            {
                return subtree;
            }

            foreach (var child in subtree.Children)
            {
                element = this.DfsGetElementById(child, idValue);
            }

            return element;
        }

        private bool DfsCheckHtmlExist(IHtmlElement subtree, IHtmlElement htmlElement)
        {
            bool result = false;

            if (subtree.Equals(htmlElement))
            {
                return true;
            }

            foreach (var child in subtree.Children)
            {
                result = this.DfsCheckHtmlExist(child, htmlElement);
            }

            return result;
        }

        private IHtmlElement DfsGetElementByType(IHtmlElement subtree, ElementType type)
        {
            IHtmlElement result = null;

            if (subtree.Type.Equals(type))
            {
                return subtree;
            }

            foreach (var child in subtree.Children)
            {
                result = this.DfsGetElementByType(child, type);
            }

            return result;
        }

        private void DfsGetElementsByType(IHtmlElement subtree, List<IHtmlElement> elements, ElementType type)
        {
            foreach(var child in subtree.Children)
            {
                this.DfsGetElementsByType(child, elements, type);
            }

            if (subtree.Type.Equals(type))
            {
                elements.Add(subtree);
            }
        }

        private IHtmlElement DfsGetHtmlElement(IHtmlElement subtree, IHtmlElement parent)
        {
            IHtmlElement result = null;

            if (subtree.Equals(parent))
            {
                return subtree;
            }

            foreach (var child in subtree.Children)
            {
                result = this.DfsGetHtmlElement(child, parent);
            }

            return result;
        }

        private void ValidateElementIsNotNull(IHtmlElement element)
        {
            if (element == null)
            {
                throw new InvalidOperationException();
            }
        }

        private void DfsGetRootAsString(IHtmlElement subtree, StringBuilder sb, int cnt)
        {
            sb.AppendLine(new string(' ', cnt) + subtree.Type.ToString());

            foreach (var child in subtree.Children)
            {
                this.DfsGetRootAsString(child, sb, cnt + 2);
            }
        }
    }
}
