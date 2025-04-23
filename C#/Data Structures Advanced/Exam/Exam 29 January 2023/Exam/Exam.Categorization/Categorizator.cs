namespace Exam.Categorization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Categorizator : ICategorizator
    {
        HashSet<Category> categories = new HashSet<Category>();
        Dictionary<string, Category> byId = new Dictionary<string, Category>();

        public void AddCategory(Category category)
        {
            if (this.byId.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            this.categories.Add(category);
            this.byId[category.Id] = category;
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!this.byId.ContainsKey(childCategoryId) || !this.byId.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            Category child = this.byId[childCategoryId];
            Category parent = this.byId[parentCategoryId];

            if (parent.Children.Contains(child))
            {
                throw new ArgumentException();
            }

            child.Parent = parent;
            parent.Children.Add(child);
        }

        public void RemoveCategory(string categoryId)
        {
            if (!this.byId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = this.byId[categoryId];

            if (category.Parent != null)
            {
                Category parent = category.Parent;
                parent.Children.Remove(category);
                category.Parent = null;
            }

            //Stack<Category> stack = new Stack<Category>();
            Queue<Category> queue = new Queue<Category>();
            //queue.Enqueue(category);

            //while (0 < queue.Count)
            //{
            //    Category element = queue.Dequeue();
            //    stack.Push(element);

            //    foreach (var child in element.Children)
            //    {
            //        queue.Enqueue(child);
            //    }
            //}

            //while (0 < stack.Count)
            //{
            //    Category element = stack.Pop();
            //    Category parent = element.Parent;
            //    parent.Children.Remove(element);
            //    element.Parent = null;
            //    this.categories.Remove(element);
            //    this.byId.Remove(element.Id);
            //}

            foreach (var child in category.Children)
            {
                child.Parent = null;
                queue.Enqueue(child);
            }

            while (queue.Count > 0)
            {
                Category element = queue.Dequeue();
                element.Parent = null;

                foreach (var child in element.Children)
                {
                    child.Parent = null;
                }

                this.categories.Remove(element);
                this.byId.Remove(element.Id);
            }

            category.Children.Clear();

            //this.DfsRemoveChildrenInDepth(category);
            this.categories.Remove(category);
            this.byId.Remove(categoryId);
        }

        private void DfsRemoveChildrenInDepth(Category element)
        {
            Category category = element;

            if (category.Children.Count == 0)
            {
                Category parent = category.Parent;
                parent.Children.Remove(category);
                category.Parent = null;
                this.categories.Remove(category);
                this.byId.Remove(category.Id);
                return;
            }

            while (0 < category.Children.Count)
            {
                this.DfsRemoveChildrenInDepth(category.Children.First());
            }

            return;
        }

        public bool Contains(Category category)
        {
            return this.byId.ContainsKey(category.Id);
        }

        public int Size()
        {
            return this.categories.Count;
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {

            if (!this.byId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            LinkedList<Category> result = new LinkedList<Category>();

            Queue<Category> queue = new Queue<Category>();
            queue.Enqueue(this.byId[categoryId]);

            while (0 < queue.Count)
            {
                Category category = queue.Dequeue();

                result.AddLast(category);

                foreach (var child in category.Children)
                {
                    queue.Enqueue(child);
                }
            }

            result.RemoveFirst();

            return result;
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!this.byId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = this.byId[categoryId];

            LinkedList<Category> categories = new LinkedList<Category>();

            while (category != null)
            {
                categories.AddFirst(category);
                category = category.Parent;
            }

            return categories;
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            List<Category> result = new List<Category>();

            SortedDictionary<int, List<Category>> byDepth = new SortedDictionary<int, List<Category>>();

            foreach (var category in this.categories)
            {
                int depth = 0;
                int cnt = 0;
                depth = this.GetTop3CategoriesOrderedByDepthOfChildrenThenByName(depth, cnt, category);

                if (!byDepth.ContainsKey(depth))
                {
                    byDepth[depth] = new List<Category>();
                }

                byDepth[depth].Add(category);
            }

            foreach (var kvp in byDepth.Reverse())
            {
                foreach (var element in kvp.Value.OrderBy(x => x.Name))
                {
                    result.Add(element);

                    if (result.Count == 3)
                    {
                        break;
                    }
                }

                if (result.Count == 3)
                {
                    break;
                }
            }

            return result;
        }

        private int GetTop3CategoriesOrderedByDepthOfChildrenThenByName(int depth, int cnt, Category category)
        {
            if (category.Children.Count == 0)
            {
                return depth;
            }

            foreach (var child in category.Children)
            {
                depth = this.GetTop3CategoriesOrderedByDepthOfChildrenThenByName(depth, cnt++, child);
            }

            return depth;
        }
    }
}
