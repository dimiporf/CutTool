using Xunit;

namespace CutTool.UnitTests
{
    public class InputParserTests
    {
        [Fact]
        public void ParseFilePath_WithValidArgs_ReturnsFilePath()
        {
            // Arrange
            string[] args = { "file.txt" };

            // Act
            string filePath = InputParser.ParseFilePath(args);

            // Assert
            Assert.Equal("file.txt", filePath);
        }

        [Fact]
        public void ParseDelimiter_WithValidArgs_ReturnsDelimiter()
        {
            // Arrange
            string[] args = { "-delim", "," };

            // Act
            string delimiter = InputParser.ParseDelimiter(args);

            // Assert
            Assert.Equal(",", delimiter);
        }

        [Fact]
        public void ParseFieldList_WithValidArgs_ReturnsFieldList()
        {
            // Arrange
            string[] args = { "-field", "1,2,3" };

            // Act
            int[] fieldList = InputParser.ParseFieldList(args);

            // Assert
            Assert.NotNull(fieldList);
            Assert.Equal(3, fieldList.Length);
            Assert.Equal(1, fieldList[0]);
            Assert.Equal(2, fieldList[1]);
            Assert.Equal(3, fieldList[2]);
        }

        [Fact]
        public void ParseUniqueFlag_WithValidArgs_ReturnsTrue()
        {
            // Arrange
            string[] args = { "-uniq" };

            // Act
            bool uniqueFlag = InputParser.ParseUniqueFlag(args);

            // Assert
            Assert.True(uniqueFlag);
        }
    }
}
