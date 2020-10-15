using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Xml.Serialization;


namespace StorageSystemSimulator.Cores
{
    public class SimulatorArticleMasterSetCore
    {
        private bool articleMasterResult = true;
        private string articleMasterResultText;
        private List<PISArticle> masterArticleList;

        public SimulatorArticleMasterSetCore()
        {
            this.masterArticleList = new List<PISArticle>();
        }

        public void ProcessArticleMasterSetRequest(ArticleMasterSetRequest articleMasterSetRequest)
        {
            if (this.articleMasterResult)
            {
                this.masterArticleList = articleMasterSetRequest.PISArticles;
                this.DoMasterArticleUpdated();
            }

            ArticleMasterSetResponse articleMasterSetResponse = new ArticleMasterSetResponse();
            articleMasterSetResponse.AdoptHeader(articleMasterSetRequest);
            articleMasterSetResponse.SetResult = this.articleMasterResult;
            articleMasterSetResponse.SetResultText = this.articleMasterResultText;

            articleMasterSetResponse.ConverterStream.Write(articleMasterSetResponse);
        }

        private void DoMasterArticleUpdated()
        {
            if (this.MasterArticleUpdated != null)
            {
                this.MasterArticleUpdated(this, null);
            }
        }

        public bool ArticleMasterResult { get { return this.articleMasterResult; } set { this.articleMasterResult = value; } }

        public string ArticleMasterResultText { get { return this.articleMasterResultText; } set { this.articleMasterResultText = value; } }

        public List<PISArticle> MasterArticleList { get { return this.masterArticleList; } }

        public event EventHandler MasterArticleUpdated;
    }
}
