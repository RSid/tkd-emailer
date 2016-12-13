﻿using System.Windows.Forms;
using static TKD.Emailer.Helpers.DataGridHelper;

namespace TKD.Emailer.Services
{
    internal class SearchService
    {
        private readonly DbService m_dbService;

        private static readonly string SelectSql = $@"
SELECT personalprofiles.id, 
    personalprofiles.fname as {FirstNameColumnName}, 
    personalprofiles.lname as {LastNameColumnName}, 
    personalprofiles.email as {EmailColumnName}, 
    personalprofiles.NextRank,
 personalprofiles.categoryid,
-DateDiff('yyyy', Now(), personalprofiles.birthday) as Age
FROM personalprofiles  
   INNER JOIN ranks ON personalprofiles.NextRank=ranks.name
WHERE email LIKE '%@%' ";

        public SearchService(DbService dbService)
        {
            m_dbService = dbService;
        }

        public string BuildSql(string checkedRankButtonName, string checkedGenderButtonName, 
            int? selectedCategoryId, string ageCategoryButtonName)
        {
            var sql = SelectSql;
            sql = ApplyGenderSelectors(sql, checkedGenderButtonName);
            sql = ApplyRankSelectors(sql, checkedRankButtonName);
            sql = ApplyCategorySelector(sql, selectedCategoryId);
            sql = ApplyAgeSelector(sql, ageCategoryButtonName);

            sql += " ORDER BY lname";
            return sql;
        }

        private string ApplyAgeSelector(string sql, string ageCategoryButtonName)
        {
            if (ageCategoryButtonName == SearchForm.AllConstant)
            {
                return sql;
            }

            if (ageCategoryButtonName == "Children")
            {
                var ageFilter = $" AND (-DateDiff('yyyy', Now(), personalprofiles.birthday)) < {SearchForm.MinAdult}";
                sql += ageFilter;
            }

            if (ageCategoryButtonName == "Adults")
            {
                var ageFilter = $" AND (-DateDiff('yyyy', Now(), personalprofiles.birthday)) >= {SearchForm.MinAdult}";
                sql += ageFilter;
            }

            return sql;
        }

        private string ApplyCategorySelector(string sql, int? selectedCategoryId)
        {
            if (selectedCategoryId == null || selectedCategoryId == SearchForm.NoneId)
            {
                return sql;
            }

            var selectedCategory = $" AND categoryid = {selectedCategoryId.Value}";
            sql += selectedCategory;

            return sql;
        }

        public string ApplyGenderSelectors(string sql, string checkedGenderButtonName)
        {
            string selectedGenderStrings = null;
            if (checkedGenderButtonName == "FemaleRadioButton")
            {
                selectedGenderStrings = "'F', 'Female', 'Fenmale'";
            }
            if (checkedGenderButtonName == "MaleRadioButton")
            {
                selectedGenderStrings = "'M', 'Male'";
            }

            if (selectedGenderStrings != null)
            {
                sql += $" AND sex IN ({selectedGenderStrings})";
            }
            return sql;
        }

        public string ApplyRankSelectors(string sql, string checkedRankButtonName)
        {
            string rankFilterString = null;
            if (checkedRankButtonName == "ColorBeltsRadioButton")
            {
                rankFilterString = " AND rorder < 11";
            }
            if (checkedRankButtonName == "BlackBeltsRadioButton")
            {
                rankFilterString = " AND rorder > 10";
            }
            if (rankFilterString != null)
            {
                sql += rankFilterString;
            }

            return sql;
        }

        public DataGridView Search(string sql)
        {
            return m_dbService.Search(sql);
        }
    }
}
