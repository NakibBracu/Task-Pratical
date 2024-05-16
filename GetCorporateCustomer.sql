CREATE PROCEDURE GetCorporateCustomerName
AS
BEGIN
    SELECT ct.Name
    FROM [TaskPractical].[dbo].[Corporate_Customer_Tbl] cct
    INNER JOIN [TaskPractical].[dbo].[Customers] ct ON cct.Id = ct.Id;
END;
