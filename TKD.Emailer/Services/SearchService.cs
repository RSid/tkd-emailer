using System;
using System.Windows.Forms;
using static TKD.Emailer.Helpers.DataGridHelper;

namespace TKD.Emailer.Services
{
    internal class SearchService
    {
        private readonly DbService m_dbService;

        private static readonly string LeftJoinSelect = $@"
SELECT 
    personalprofiles.fname as {FirstNameColumnName}, 
    personalprofiles.lname as {LastNameColumnName}, 
    personalprofiles.email as {EmailColumnName}, 
    personalprofiles.NextRank,
-DateDiff('yyyy', Now(), personalprofiles.birthday) as Age,
memberof1 as Club_Membership
FROM personalprofiles  
   LEFT JOIN ranks ON personalprofiles.NextRank=ranks.name
WHERE email LIKE '%@%' ";

private static readonly string RightJoinSelect = $@"
SELECT  
    personalprofiles.fname as {FirstNameColumnName}, 
    personalprofiles.lname as {LastNameColumnName}, 
    personalprofiles.email as {EmailColumnName}, 
    personalprofiles.NextRank,
-DateDiff('yyyy', Now(), personalprofiles.birthday) as Age,
memberof1 as Club_Membership
FROM personalprofiles  
   RIGHT JOIN ranks ON personalprofiles.NextRank=ranks.name
WHERE email LIKE '%@%' ";

        public SearchService(DbService dbService)
        {
            m_dbService = dbService;
        }

        public string BuildSql(string checkedRankButtonName, int? rankMin, int? rankMax, string checkedGenderButtonName, 
            int? selectedCategoryId, string ageCategoryButtonText, int? ageMin, int? ageMax, string clubMembershipButtonText)
        {
            var leftSql = LeftJoinSelect;
            leftSql = ApplyGenderSelectors(leftSql, checkedGenderButtonName);
            leftSql = ApplyRankSelectors(leftSql, checkedRankButtonName, rankMin, rankMax);
            leftSql = ApplyCategorySelector(leftSql, selectedCategoryId);
            leftSql = ApplyAgeSelector(leftSql, ageCategoryButtonText, ageMin, ageMax);
            leftSql = ApplyMembershipSelectors(leftSql, clubMembershipButtonText);

            var rightSql = RightJoinSelect;
            rightSql = ApplyGenderSelectors(rightSql, checkedGenderButtonName);
            rightSql = ApplyRankSelectors(rightSql, checkedRankButtonName, rankMin, rankMax);
            rightSql = ApplyCategorySelector(rightSql, selectedCategoryId);
            rightSql = ApplyAgeSelector(rightSql, ageCategoryButtonText, ageMin, ageMax);
            rightSql = ApplyMembershipSelectors(rightSql, clubMembershipButtonText);

            var finalSql = $"{leftSql} UNION {rightSql} ORDER BY {LastNameColumnName}";
            return finalSql;
        }

        private string ApplyMembershipSelectors(string sql, string clubMembershipButtonText)
        {
            if (clubMembershipButtonText == SearchForm.AllConstant)
            {
                return sql;
            }

            if (clubMembershipButtonText == SearchForm.BlackBeltClubText)
            {
                var membershipFilterSql = $" AND memberof1 = '{SearchForm.BlackBeltClubText}'";
                sql += membershipFilterSql;
            }

            if (clubMembershipButtonText == SearchForm.FoundersClubText)
            {
                var membershipFilterSql = $" AND memberof1 = '{SearchForm.FoundersClubText}'";
                sql += membershipFilterSql;
            }

            return sql;
        }

        private string ApplyAgeSelector(string sql, string ageCategoryButtonText, int? ageMin, int? ageMax)
        {
            if (ageCategoryButtonText == SearchForm.AllConstant)
            {
                return sql;
            }

            if (ageCategoryButtonText == SearchForm.ChildrenText)
            {
                var ageFilter = $" AND (-DateDiff('yyyy', Now(), personalprofiles.birthday)) < {SearchForm.MinAdult}";
                sql += ageFilter;
            }

            if (ageCategoryButtonText == SearchForm.AdultsText)
            {
                var ageFilter = $" AND (-DateDiff('yyyy', Now(), personalprofiles.birthday)) >= {SearchForm.MinAdult}";
                sql += ageFilter;
            }

            if (ageCategoryButtonText == SearchForm.AgeRangeText)
            {
                if (ageMin == null || ageMax == null)
                {
                    throw new ArgumentException("Invalid input for age range. Please select an integer.");
                }
                var ageFilter = $" AND ( (-DateDiff('yyyy', Now(), personalprofiles.birthday)) >= {ageMin} AND (-DateDiff('yyyy', Now(), personalprofiles.birthday)) <= {ageMax})";
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

        public string ApplyRankSelectors(string sql, string checkedRankButtonName, int? rankMin, int? rankMax)
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
            if (rankMin != null && rankMax != null)
            {
                rankFilterString = $" AND (rorder >= {rankMin} AND rorder <= {rankMax})";
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
