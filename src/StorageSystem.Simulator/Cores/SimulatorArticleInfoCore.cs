using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareFusion.Mosaic.Converters.Wwks2.Messages;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages.ArticleInformation;

namespace StorageSystemSimulator.Cores
{
    public delegate void ArticleInfoResponseReceivedEventHandler(object sender, ArticleInfoResponse articleInfoResponse);

    public class SimulatorArticleInfoCore
    {
        private int _subscriberID;
        private List<IConverterStream> _converterStreamList;
        private List<Article> _articleList;

        public List<Article> ArticleList { get { return _articleList; } }

        public SimulatorArticleInfoCore()
        {
            _articleList = new List<Article>();
        }

        public void Initialize(List<IConverterStream> converterStreamList)
        {
            _converterStreamList = converterStreamList;
        }
        public void SetSubscriberID(int subscriberID)
        {
            _subscriberID = subscriberID;
        }

        public void SendArticleInfoRequest(string tenantId)
        {
            foreach (IConverterStream stream in _converterStreamList)
            {
                if ((tenantId != stream.TenantID)
                    && (!string.IsNullOrEmpty(tenantId)))
                {
                    continue;
                }

                ArticleInfoRequest articleInfoRequest = new ArticleInfoRequest(stream)
                {
                    ID = MessageId.Next,
                    Source = _subscriberID, // default
                    Destination = int.Parse(stream.Destination),
                };

                articleInfoRequest.Articles = new Article[_articleList.Count];
                for (int i = 0; i < _articleList.Count; ++i)
                {
                    articleInfoRequest.Articles[i] = _articleList[i];
                }

                stream.Write(articleInfoRequest);
            }
        }

        public void ProcessArticleInfoResponse(ArticleInfoResponse articleInfoResponse)
        {
            this.DoArticleInfoResponseReceived(articleInfoResponse);
        }
        private void DoArticleInfoResponseReceived(ArticleInfoResponse articleInfoResponse)
        {
            if (this.ArticleInfoResponseReceived != null)
            {
                this.ArticleInfoResponseReceived(this, articleInfoResponse);
            }
        }

        public event ArticleInfoResponseReceivedEventHandler ArticleInfoResponseReceived;
    }
}
