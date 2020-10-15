using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystemSimulator
{
    public class StorageSystemArticleInformation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DosageForm { get; set; }
        public string PackagingUnit { get; set; }
        public int MaxSubItemQuantity { get; set; }
    }
#warning doto here, migrate to PIS code.
    [DataContract]
    public class StorageSystemArticleInformationList
    {
        [DataMember]
        private Dictionary<string, StorageSystemArticleInformation> acticleList;
        
        public StorageSystemArticleInformationList()
        {
            this.acticleList = new Dictionary<string, StorageSystemArticleInformation>();
        }

        public StorageSystemArticleInformation GetArticleInformation(string productCode, bool createIfMissing)
        {
            if (this.acticleList.ContainsKey(productCode))
            {
                return this.acticleList[productCode];
            }
            else
            {
                if (createIfMissing)
                {
                    StorageSystemArticleInformation newArticle = new StorageSystemArticleInformation();
                    newArticle.Code = productCode;
                    this.acticleList.Add(productCode, newArticle);
                    return newArticle;
                }
            }

            return null;
        }

        public void Clear()
        {
            this.acticleList.Clear();
        }

        public List<StorageSystemArticleInformation> ArticlesAsList { get { return this.acticleList.Values.ToList();  } }
    }
}
