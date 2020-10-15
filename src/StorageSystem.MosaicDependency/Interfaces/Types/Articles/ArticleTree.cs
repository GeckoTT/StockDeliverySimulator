using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    public class ArticleTree<T> where T : class, new()
    {
        private T _article;
        private List<ArticleTree<T>> _children;
        public ArticleTree()
        {
            _article = new T();
            _children = new List<ArticleTree<T>>();
        }

        public void AddChild(ArticleTree<T> child)
        {
            _children.Add(child);
        }

        public T GetArticle()
        {
            return _article;
        }

        public List<ArticleTree<T>> GetChildren()
        {
            return _children;
        }
    }
}
