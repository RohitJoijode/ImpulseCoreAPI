using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImpulseCoreAPI.DAL
{
    #region DimProduct

    public class DimProduct

    {

        public int ProductKey { get; set; }

        public string ProductAlternateKey { get; set; }

        public int? ProductSubcategoryKey { get; set; }

        public string WeightUnitMeasureCode { get; set; }

        public string SizeUnitMeasureCode { get; set; }

        public string EnglishProductName { get; set; }

        public string SpanishProductName { get; set; }

        public string FrenchProductName { get; set; }

        public decimal? StandardCost { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        public string Color { get; set; }

        public short? SafetyStockLevel { get; set; }

        public short? ReorderPoint { get; set; }

        public decimal? ListPrice { get; set; }

        public string Size { get; set; }

        public string SizeRange { get; set; }

        public double? Weight { get; set; }

        public int? DaysToManufacture { get; set; }

        public string ProductLine { get; set; }

        public decimal? DealerPrice { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public string ModelName { get; set; }

        public byte[] LargePhoto { get; set; }

        public string EnglishDescription { get; set; }

        public string FrenchDescription { get; set; }

        public string ChineseDescription { get; set; }

        public string ArabicDescription { get; set; }

        public string HebrewDescription { get; set; }

        public string ThaiDescription { get; set; }

        public string GermanDescription { get; set; }

        public string JapaneseDescription { get; set; }

        public string TurkishDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; }

    }

    #endregion


    #region DimAccount
    [Table("DimAccount")]
    public class DimAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 1)]
        public int AccountKey { get; set; }

        public int? ParentAccountKey { get; set; }

        public int? AccountCodeAlternateKey { get; set; }

        public int? ParentAccountCodeAlternateKey { get; set; }

        public string AccountDescription { get; set; }

        public string AccountType { get; set; }

        public string Operator { get; set; }

        public string CustomMembers { get; set; }

        public string ValueType { get; set; }

        public string CustomMemberOptions { get; set; }

    }
    #endregion

    #region FilePathString
    [Table("FilePathString")]
    public class FilePathString
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 1)]
        public int Id { get; set; }
       public string FilePath { get; set; }
    }
    #endregion


}
