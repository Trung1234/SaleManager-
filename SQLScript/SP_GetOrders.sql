
USE [SaleDB1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or ALTER  PROCEDURE [dbo].[GetOrders]
            @Id varchar(150)
        AS  
    
            select * from Orders where UserId = @Id
			order by ID
        
GO




