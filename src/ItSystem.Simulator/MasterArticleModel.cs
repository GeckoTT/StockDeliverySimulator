using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains the data model for the master article set.
    /// </summary>
    public class MasterArticleModel
    {
        #region Members

        /// <summary>
        /// Master article data model.
        /// </summary>
        private DataTable _masterArticleModel = new DataTable();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the master article data model.
        /// </summary>
        public DataTable MasterArticles
        {
            get { return _masterArticleModel; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterArticleModel"/> class.
        /// </summary>
        public MasterArticleModel()
        {
            DataColumn column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ArticleID";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Name";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Dosage";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Packaging";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Fridge";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "MaxSubItems";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "StockLocation";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "MachineLocation";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Virtual Article Id";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Virtual Article Name";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Serial Number Tracking";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Batch Number Tracking";

            column = _masterArticleModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Expiry Date Tracking";
        }

        /// <summary>
        /// Generates virtual master articles which can be used for test scenarios.
        /// </summary>
        public void GenerateMasterArticles()
        {
            _masterArticleModel.Rows.Clear();

            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09284708", "QUETIAPIN BETA 200MG FILMTA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, true, true, true });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09231209", "DONEPEZIL HCL BETA10MG SCHM", "", "98 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09231132", "DONEPEZIL HCL BETA 10MG FTA", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09289870", "CANDESARTAN ACTAV COM8/12,5", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09284766", "QUETIAPIN BETA 300MG FILMTA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09231089", "DONEPEZIL HCL BETA 5MG FITA", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05534120", "DOXAZOSIN 4 TABLETT NORISPH", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00748862", "LEVO C AL 200/50 TABLETTEN", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01035911", "TOXOGONIN AMPULLEN 0,25", "", "5X1 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01073975", "BIOCH 11 SILIC D6 TAB BOMBA", "", "80 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00586069", "VIAGRA 25MG FILMTABL KOHL", "", "4 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05535214", "ITRACONAZOL NORISP 100 HAKA", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00190130", "TORASEMID ACTAVIS 5MG TABL", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02681323", "TRIMIDURA 100MG FILMTABLETT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03774133", "NEBIVOLOL HEUMANN 5MG TABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03357990", "DISCI INTERV LUM GL D5 AMP", "", "10X1 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09478401", "QUETIAPIN CT 100MG FILMTABL", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00047220", "FURO 500 CT TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09266797", "RIVASTIGMIN HEXA 3MG HARTKA", "", "112 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04610190", "LANSOPRAZOL 1A PHARM 15 KAP", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05371586", "CETIRIZIN ACTAVIS 10MG FITA", "", "7 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01390954", "CITALOPRAM HEXAL 40MG FILMT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00801332", "METFORMIN SANDOZ 850 FILMTA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02774898", "LANSOPRAZOL HEXAL 30 HARTKA", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04853538", "ESTRADIOL 75 UNO TTS 1A PHA", "", "16 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09243336", "QUETIAPIN CT 100MG FILMTABL", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08878943", "DONEPEZIL AAA 10MG FILMTABL", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09494937", "QUETIAPIN 1A PHA 300MG FITA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09338864", "OXCARBAZEPIN HEXAL 300MG FT", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09266768", "RIVASTIGMIN HEXA 1,5MG HAKA", "", "112 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05481323", "GLIMEPIRID AL 3MG TABLETTEN", "", "180 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01981081", "ARCASIN 1,5 MIO FILMTABLETT", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01146504", "SPIRUSELEN SELEN SPIRULI TA", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08861983", "METHYLPREDNISOLO 16 ACIS TA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01016351", "METFORMIN ABZ 850 FILMTABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01953736", "GASTROZOL 20MG TABLETTEN", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06108365", "LAMICTAL 50MG TABLETTEN", "", "42 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09445577", "QUETIAPIN NEURAX 100MG FITA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08878883", "DONEPEZIL AAA 5MG FILMTABL", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01958604", "GASTROZOL 40MG TABLETTEN", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04979647", "SUMATRIPTAN WINTHR 50MG FTA", "", "12 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02250014", "CITALOPRAM STADA 20MG FILMT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04609465", "OPIPRAMOL RATIO 100MG FILMT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03433426", "TRIMIPRAMIN RATIO 25MG TABL", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02250008", "CITALOPRAM STADA 20MG FILMT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01414175", "SPIROGAMMA 50 TABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09262546", "QUETIAPIN STADA 100MG FILMT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01573034", "OXALIS COMP DIL WELEDA", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09190692", "PANTOPRAZOL WINTHR 40MG TAB", "", "15 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03257308", "IMBUN FILMTABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08861368", "INDAPAMID CT 2,5MG HARTKAPS", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01530303", "FELODIPIN CT 5MG RETARDTABL", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04632530", "VERTIZIN TROPFEN", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01550375", "HCT RATIOPHARM 25MG TABLETT", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09383304", "QUETIAPIN ACIS 25MG FILMTAB", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09243230", "QUETIAPIN RATIO 200MG FILMT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09283761", "QUETIAPIN BIOMO 300MG FILMT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09445749", "QUETIAPIN NEURAX 300MG FITA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08753153", "LETROAROM 2,5MG FILMTABLETT", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08859118", "METHYLPREDNISOLON 4 ACIS TA", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03467218", "EUCALYPTUS 73        SYNERG", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09392332", "CANDESARTAN ZENT COMP8/12,5", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04042604", "RATACAND PROTEC 32MG TA EUR", "", "98 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00238552", "MOXONIDIN HEUMANN 0,3MG FTA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04320167", "VIAGRA 50MG FILMTABL EURIM", "", "12 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04879319", "COPEGUS 200MG FILMTABL EURI", "", "168 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05499197", "OMELICH 40MG HARTKAPSELN", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03635762", "SYNERGON KOMPL KREOSOT N160", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04798029", "RISPERIDON RATIO 2MG FILMTA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02556150", "ISDN 60 RATIOPHARM RET KAPS", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04405461", "TERBINAFIN STADA 250MG TABL", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00180640", "SULPIRID 200 STADA TABLETT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03171104", "MONO MACK DEPOT RETARDTABL", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01261978", "AVELOX 400MG FILMTABL EURIM", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00425018", "SERTRALIN NEURAX 100MG FITA", "", "60 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09643099", "ZINKGLUKONAT 25MG TABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04780319", "INFIPECT TROPFEN", "", "20 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05394788", "CLOZAPIN NEURAXPHARM 100 TA", "", "60 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00393778", "SERTRALIN NEURAX 50MG FILMT", "", "90 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01033473", "MICTONORM DRAGEES EURIM", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05968321", "CIPROFLOXACIN BIOMO 250 FTA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01686761", "VIRILIS GASTREU S R41 TROPF", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09002673", "IS 5 MONO RATIO 40MG RETTAB", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07260655", "VALPROINSAEURE RATIO 150 FT", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04875209", "METOPROLOL 200 RATIO RETTAB", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03424700", "TRIMIPRAMIN RATIO 25MG TABL", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00188239", "TASMAR 100MG FILMTABL KOHL", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09389689", "ZOLMITRIPTAN STAD2,5MG SCHM", "", "12 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04405343", "TERBINAFIN STADA 125MG TABL", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01253772", "LOSARTAN STADA 12,5MG FILMT", "", "21 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00244067", "LEVODOPA COMP B STAD 200/50", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00180634", "SULPIRID 200 STADA TABLETT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02213119", "CARVEDIGAMMA 25MG FILMTABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03898817", "MIRTAGAMMA 30MG FILMTABLETT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08415769", "CARBAGAMMA 200 TABLETTEN", "", "200 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02502450", "LEKA 500 TABLETTEN", "", "60 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07583134", "VERA HEUMANN 120 FILMTABLET", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00069575", "NORFLOXACIN RATIO 400 FILMT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04347077", "STROGEN UNO KAPSELN", "", "60 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00204702", "FENOFIBRAT 250 RETKAP STADA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05380533", "ALENDRON WINT 1XWOECH 70 TA", "", "4 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04890870", "VENENSORIN N TROPFEN", "", "30 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05107493", "PROPIMEDAC 15MG FILMTABLETT", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07265575", "BICALUTAMID WINTHR 150MG FT", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06707137", "BICALUTAMID BIOMO 50MG FITA", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01121757", "TIAPRID NEURAX 200MG FILMTA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06486446", "NEYCORENAR 6 D7 AMPULLEN", "", "5X2 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00558222", "CUTASON 5MG TABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03045405", "MIRTAZAPIN BIOMO 15MG FILMT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09781909", "FORTICOR BIOMO KAPSELN", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00664007", "GLIMEPIRID BIOMO 4MG TABLET", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05743355", "PROTITIS COMP TROPFEN", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04804913", "METODURA 100 TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07406018", "RIVASTIGMIN HEUM 6MG HARTKA", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03781156", "FLUCONAZOL ISIS 150MG KAPS", "", "1 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00662356", "AKINETON RETARD TABL BERAGE", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03914953", "HERZTROPFEN N COSMOCHEMA", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01351138", "CARBO VEG SIMILIAPLEX", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00919507", "SCHWEF HEEL LIQUIDUM", "", "100 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08533078", "HAUTFUNKTIONSTABLETT N COSM", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03331217", "RISPERIDON AL 0,25MG FILMTA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03356795", "GLANDULAE SUPR GL D10 AM WA", "", "10X1 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00536143", "LEVOCOMP 100/25MG TABLETTEN", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02251522", "AZAIMUN 50MG TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04996611", "SOTABETA 80 TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06715817", "CYPROTERONACETA BETA 100 TA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09231072", "DONEPEZIL HCL BETA 5MG FITA", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01073751", "BIOCH 8 NATR CHL D12 TA BOM", "", "80 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08755471", "EDRONAX 4MG TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09285493", "DONEPEGAMMA 10MG FILMTABLET", "", "98 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03964916", "METOPROLOL 200 CT RETARDTAB", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02193842", "CYCLAMEN KOMPLEX HANOSAN", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09264580", "QUETIAPIN CT 300MG RETARDTA", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08877984", "LEVOFLOXACIN BLUEF 250MG FT", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00801303", "METFORMIN SANDOZ 500 FILMTA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03521691", "JUVENTAL 25 FILMTABLETTEN", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08791461", "ARYNX GASTREU R 45 TROPFEN", "", "22 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04664820", "HEPA GASTREU N R7 TROPFEN", "", "22 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04163526", "NUX VOMICA GASTREU R52 TROP", "", "22 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08517808", "NIFATENOL 50 RETARDKAPSELN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09266840", "RIVASTIGMIN HEXA 6MG HARTKA", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06440059", "SIFROL 2,10MG RETARDTAB WES", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03416758", "URBASON TABLETT 40MG EMRA", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09338835", "OXCARBAZEPIN HEXAL 600MG FT", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05507146", "REPAGLINID HEXAL 4MG TABLET", "", "120 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08538118", "CAPTOHEXAL COMP 25/12,5 TAB", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01821466", "ZIPSILAN 40MG HARTKAPSELN", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02457301", "DOXAZOSIN 8 TABLETTEN AL", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05535237", "ITRACONAZOL NORISP 100 HAKA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00526328", "ARISTOLOCHIA CLEM D12AM STA", "", "10X1 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06695960", "RUTA D4 AMP STAUFEN", "", "10X1 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00166686", "DIANE 35 DRAGEES KOHL PHARM", "", "3X21 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00646742", "TRAMADOLOR 150 ID RET TABL", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07590312", "AMIOHEXAL 200 TABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09339131", "QUETIAPIN HEXAL 50MG FILMTA", "", "10 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07687081", "DILTAHEXAL 60 FILMTABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09937398", "AMELIE 1A PHA 0,03MG/2MG FT", "", "21 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04390966", "OPIPRAMOL HEXAL 50MG FILMTA", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02136212", "SEROQUEL 300MG FILMTABLETT", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01686554", "GRIPPE GASTREU S R6 TROPFEN", "", "22 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03694753", "REVET H 3C GLOB VET", "", "10 GR", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02160222", "ATENOLOL AAA 50 TABLETTEN", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09487618", "OLANZAPIN BIOMO 5MG UEBZ TA", "", "35 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04775459", "LITHIUM APOGEPHA TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04873771", "DONEURIN 10 KAPSELN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02203629", "CONDOMI NATURE KONDOME", "", "3 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04015777", "FLUCONAZOL RATIO 50MG KAPS", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03051104", "DOXAZOSIN 2MG URO TAB HEXAL", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08538124", "CAPTOHEXAL COMP 25/12,5 TAB", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00565305", "DILATREND 3,125MG TABLETTEN", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00581296", "LOSAR TEVA 25MG FILMTABLETT", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08758529", "VALSARTAN BIOMO COMP 320/25", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01812094", "ASCLEPIAS OLIGOPLEX LIQUID", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09750808", "RIVASTIGMIN NEURA 1,5MG HKA", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01686784", "FUCUS GASTREU S R59 TROPFEN", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04451863", "CAPSICUM OLIGOPLEX LIQUIDUM", "", "50 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02850398", "PANTOPRAZOL ARISTO 40MG TAB", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "05900607", "PROPIVERIN SANDOZ 15MG FITA", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08442157", "OLANZAPIN CT 5MG TABLETTEN", "", "35 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03910731", "TRIMIPRAMIN CT 25 TABLETTEN", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03123163", "MIRTAZAPIN ABZ 45MG FILMTAB", "", "20 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04435315", "TIAPRID HEXAL 100MG TABLETT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03451424", "VERATIDE TABLETTEN", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09518796", "OLANZAPIN AL 7,5MG UEBZ TAB", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07751554", "LETROZOL ACTAVIS 2,5MG FITA", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "00024087", "METFORMIN PUREN 850 FILMTAB", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02898749", "DOPPELHERZ AKTIV MENO TABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04801814", "ATEBETA 100 FILMTABLETTEN", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "09231155", "DONEPEZIL HCL BETA 5MG SCHM", "", "28 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06607571", "CITALOPRAM RATIO 30MG FILMT", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03120503", "MIRTAZAPIN RATIOPH 45MG FTA", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08814038", "LEVETIRACETAM RAT 500MG FTA", "", "50 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "08814009", "LEVETIRACETAM RAT 250MG FTA", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01024675", "TERBINAFIN RATIO 250MG TABL", "", "14 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "06958738", "GINKGO STADA TROPFEN", "", "100 ML", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03323838", "BONDRONAT 6MG DURCHSTECHFLA", "", "5 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "07782017", "LETROZOL AL 2,5MG FILMTABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "04877013", "ISOKET RETARD 40 TABLETTEN", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "02850412", "PANTOPRAZOL ARISTO 40MG TAB", "", "56 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "01054819", "GLIMEPIRID RATIOPH 1MG TABL", "", "30 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
            _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[] { "03099080", "DOMPERIDON RATIO 10MG FILMT", "", "100 ST", false, 0, string.Empty, string.Empty, null, null, false, false, false });
        }

        /// <summary>
        /// Generates master articles based on the contents of a Select database export.
        /// </summary>
        /// <param name="selectArticleFile">The file which contains the Select articles.</param>
        public void GenerateFromSelectArticleFile(string selectArticleFile)
        {
            var regex = new Regex("^\"(?<pzn>\\d+)\",\"(?<name>[^\\\"]*)\",\"(?<packaging>[^\\\"]*)\",\"(?<dosage>[^\\\"]*)\",\"(?<ean1>[^\\\"]*)\",\"(?<date>[^\\\"]*)\",\"(?<country>\\d*)\",\"(?<code>\\d*)\",\"(?<ean2>[^\\\"]*)\".*$",
                                  RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            try
            {
                var knownArticleCodes = new List<string>();

                using (var reader = new StreamReader(selectArticleFile))
                {
                    string line = string.Empty;
                    _masterArticleModel.Rows.Clear();

                    while ((line = reader.ReadLine()) != null)
                    {
                        var match = regex.Match(line);

                        if (match.Success == false)
                            continue;

                        var articleCode = match.Groups["ean1"].Value;
                        articleCode = string.IsNullOrWhiteSpace(articleCode) ? match.Groups["ean2"].Value : articleCode;
                        articleCode = string.IsNullOrWhiteSpace(articleCode) ? match.Groups["pzn"].Value.PadLeft(8, '0') : articleCode;

                        if (knownArticleCodes.Contains(articleCode))
                            continue;

                        knownArticleCodes.Add(articleCode);

                        var dosageForm = match.Groups["dosage"].Value;
                        var packagingUnit = match.Groups["packaging"].Value;

                        _masterArticleModel.Rows.Add(_masterArticleModel.NewRow().ItemArray = new object[]
                        {
                            articleCode,
                            match.Groups["name"].Value,
                            match.Groups["dosage"].Value,
                            match.Groups["packaging"].Value,
                            false, 0, string.Empty, string.Empty
                        });
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Sends the current master article set to the specified storage system.
        /// </summary>
        /// <param name="storageSystem">Storage system to send the master articles too.</param>
        public void Send(IStorageSystem storageSystem)
        {
            storageSystem.UpdateMasterArticles(LoadMasterArticleListFromModel(storageSystem, this));
        }
        
        /// <summary>
        /// Sends the current master article set to the specified storage system.
        /// </summary>
        /// <param name="storageSystem">Storage system to send the master articles too.</param>
        /// <param name="masterArticleModel">masterArticleModel list in the result master article list.</param>
        private List<IMasterArticle> LoadMasterArticleListFromModel(IStorageSystem storageSystem, MasterArticleModel masterArticleModel)
        {
            var masterArticleList = new List<IMasterArticle>();
            foreach (DataRow row in masterArticleModel.MasterArticles.Rows)
            {
                IMasterArticle currentArticle = storageSystem.CreateMasterArticle((row[0] != DBNull.Value) ? (string)row[0] : string.Empty,
                                                                        (row[1] != DBNull.Value) ? (string)row[1] : string.Empty,
                                                                        (row[2] != DBNull.Value) ? (string)row[2] : string.Empty,
                                                                        (row[3] != DBNull.Value) ? (string)row[3] : string.Empty,
                                                                        (row[4] != DBNull.Value) ? (bool)row[4] : false,
                                                                        (row[5] != DBNull.Value) ? (uint)row[5] : 0,
                                                                        (row[6] != DBNull.Value) ? (string)row[6] : null,
                                                                        (row[7] != DBNull.Value) ? (string)row[7] : null,
                                                                        (row[8] != DBNull.Value) ? (string)row[8] : null,
                                                                        (row[9] != DBNull.Value) ? (string)row[9] : null,
                                                                        (row[10] != DBNull.Value) ? (bool)row[10] : false,
                                                                        (row[11] != DBNull.Value) ? (bool)row[11] : false,
                                                                        (row[12] != DBNull.Value) ? (bool)row[12] : false);
                masterArticleList.Add(currentArticle);
            }

            return masterArticleList;
        }
    }
}
