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

        private Table CreateTable()
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

        [Fact]
        public void GenerateSQLQuery_EqualOperator()
        {
            //Arrange
            var table = CreateTable();

            //Act
            var queryGenerator = new GenerateSQLQuery();
            var result = queryGenerator.GenerateQuery(table);

            //Assert
            Assert.Equal("select * from Table1 Where Column1 = value1", result, ignoreCase: true);
        }
    }
}
