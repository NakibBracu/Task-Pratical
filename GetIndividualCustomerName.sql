Create PROCEDURE [dbo].[GetIndividualCustomerName]
AS
BEGIN
    SELECT 
	ct.Id,
	ct.Name
    FROM [TaskPractical].[dbo].[Individual_Customer_Tbl] ict
    INNER JOIN [TaskPractical].[dbo].[Customers] ct ON ict.Id = ct.Id;
END;