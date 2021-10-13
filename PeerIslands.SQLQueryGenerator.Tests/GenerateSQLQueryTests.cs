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

        [Fact]
        public void GenerateSQLQuery_EqualOperator()
        {
            //Arrange
            var table = CreateEqualTable();

            //Act
            var queryGenerator = new GenerateSQLQuery();
            var result = queryGenerator.GenerateQuery(table);

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
            var result = queryGenerator.GenerateQuery(table);

            //Assert
            Assert.Equal("select * from Table1 Where Column1 = 'value1' AND Column2 IN ('value1','value2')", result, ignoreCase: true);
        }
    }
}
