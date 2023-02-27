
CREATE PROCEDURE prc_GetAllBooks
AS
SELECT [b].[Id] , b.Name , b.Description , a.Name AS AuthorName,sc.Name AS CategoryName FROM Books b INNER JOIN Authors a ON b.AuthorId = a.Id INNER JOIN SubCategories sc ON b.BookCategoryId = sc.Id
