using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PeerIslands.SQLQueryGenerator.Tests
{
    public class GenerateSQLQueryTests
    {
        private Table CreateEqualTable()
        {
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1",
                Operator = "Equal"
            });

            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };

            return tblInput;
        }

        private Table CreateMultiTable()
        {
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1",
                Operator = "Equal",
                Condition = "AND"
            });

            columns.Add(new Column()
            {
                FieldName = "Column2",
                FieldValue = "value1;value2",
                Operator = "IN"
            });

            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };

            return tblInput;
        }

        private List<Table> CreateJoinTable()
        {
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "column1",
                FieldValue = "value",
                Operator = "Equal",
                Condition = "AND"
            });
            columns.Add(new Column()
            {
                FieldName = "column2",
                FieldValue = "value1;value2;value3",
                Operator = "IN",
                Condition = "OR"
            });
            columns.Add(new Column()
            {
                FieldName = "column3",
                FieldValue = "value1;value2",
                Operator = "Between",
                Condition = "AND"
            });
            columns.Add(new Column()
            {
                FieldName = "column4",
                FieldValue = "value",
                Operator = "like"
            });

            List<Column> joincolumns = new List<Column>();
            joincolumns.Add(new Column()
            {
                FieldName = "Table1.column1",
                FieldValue = "Table2.column1",
                Operator = "Equal",
                Condition = "AND"
            });

            joincolumns.Add(new Column()
            {
                FieldName = "Table1.column2",
                FieldValue = "Table2.column2",
                Operator = "Equal",
                Condition = "OR"
            });

            joincolumns.Add(new Column()
            {
                FieldName = "Table1.column3",
                FieldValue = "Table2.column3",
                Operator = "Equal"
            });


            List<Table> tables = new List<Table>();
            tables.Add(new Table()
            {
                TableName = "Table1",
                JoinType = "",
                Columns = columns
            });

            tables.Add(new Table()
            {
                TableName = "Table2",
                JoinType = "LEFT JOIN",
                Columns = columns,
                JoinConditions = new List<Column>(joincolumns)
            });

            return tables;
        }

        [Fact]
        public void GenerateSQLQuery_EqualOperator()
        {
            //Arrange
            var table = CreateEqualTable();

            //Act
            var queryGenerator = new GenerateSQLQuery();
            var result = queryGenerator.GenerateQuery(table, "*");

            //Assert
            Assert.Equal("select * from Table1 Where Column1 = 'value1'", result, ignoreCase: true);
        }

        [Fact]
        public void GenerateSQLQuery_MultipleOperators()
        {
            //Arrange
            var table = CreateMultiTable();

            //Act
            var queryGenerator = new GenerateSQLQuery();
            var result = queryGenerator.GenerateQuery(table, "*");

            //Assert
            Assert.Equal("select * from Table1 Where Column1 = 'value1' AND Column2 IN ('value1','value2')", result, ignoreCase: true);
        }


        [Fact]
        public void GenerateSQLQuery_JoinOperators()
        {
            //Arrange
            var tables = CreateJoinTable();

            //Act
            var queryGenerator = new GenerateSQLQuery();
            var result = queryGenerator.GenerateJoinQuery(tables, "*");

            //Assert
            Assert.Equal("select * from (select * from Table1 Where column1 = 'value' AND column2 IN ('value1','value2','value3') OR column3 BETWEEN 'value1' AND 'value2' AND column4 like '%value%' ) Table1 LEFT JOIN  (select * from Table2 Where column1 = 'value' AND column2 IN ('value1','value2','value3') OR column3 BETWEEN 'value1' AND 'value2' AND column4 like '%value%' ) Table2  ON Table1.column1 = Table2.column1 AND Table1.column2 = Table2.column2 OR Table1.column3 = Table2.column3", result, ignoreCase: true);
        }
    }
}
